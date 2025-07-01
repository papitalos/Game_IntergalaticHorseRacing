using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class AudioManager
    {
        private static bool _audioEnabled = true;
        private static readonly List<Process> _activeAudioProcesses = new List<Process>();
        private static readonly object _processLock = new object();
        
        /// <summary>
        /// Inicializa o AudioManager e configura o handler de fechamento da aplicação
        /// </summary>
        static AudioManager()
        {
            // Configura handler para quando a aplicação fechar
            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
            Console.CancelKeyPress += OnCancelKeyPress;
        }

        /// <summary>
        /// Handler chamado quando a aplicação é fechada normalmente
        /// </summary>
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            StopAllAudio();
        }

        /// <summary>
        /// Handler chamado quando Ctrl+C é pressionado
        /// </summary>
        private static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            StopAllAudio();
        }

        /// <summary>
        /// Para todos os processos de áudio ativos
        /// </summary>
        public static void StopAllAudio()
        {
            lock (_processLock)
            {
                foreach (var process in _activeAudioProcesses.ToArray())
                {
                    try
                    {
                        if (process != null && !process.HasExited)
                        {
                            process.Kill();
                            process.WaitForExit(1000); // Aguarda até 1 segundo
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ignora erros ao tentar matar o processo
                        Console.WriteLine($"⚠️  Erro ao parar processo de áudio: {ex.Message}");
                    }
                    finally
                    {
                        process?.Dispose();
                    }
                }
                _activeAudioProcesses.Clear();
            }
        }

        /// <summary>
        /// Adiciona um processo à lista de processos ativos
        /// </summary>
        private static void AddActiveProcess(Process process)
        {
            if (process == null) return;
            
            lock (_processLock)
            {
                _activeAudioProcesses.Add(process);
                
                // Remove processos que já terminaram
                _activeAudioProcesses.RemoveAll(p => p.HasExited);
            }
        }

        /// <summary>
        /// Remove um processo da lista de processos ativos
        /// </summary>
        private static void RemoveActiveProcess(Process process)
        {
            if (process == null) return;
            
            lock (_processLock)
            {
                _activeAudioProcesses.Remove(process);
            }
        }

        /// <summary>
        /// Detecta o sistema operacional atual
        /// </summary>
        private static string GetOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "Windows";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "macOS";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "Linux";
            
            return "Unknown";
        }

        /// <summary>
        /// Toca um arquivo de áudio de forma assíncrona
        /// </summary>
        /// <param name="audioFile">Nome do arquivo de áudio</param>
        public static async Task PlayAudioAsync(string audioFile)
        {
            if (!_audioEnabled) return;

            try
            {
                // Constrói o caminho para o arquivo de áudio
                string audioPath = Path.Combine("Assets", audioFile);
                
                // Verifica se o arquivo existe
                if (!File.Exists(audioPath))
                {
                    Console.WriteLine($"⚠️  Arquivo de áudio não encontrado: {audioPath}");
                    return;
                }

                string os = GetOperatingSystem();
                
                await Task.Run(() =>
                {
                    try
                    {
                        switch (os)
                        {
                            case "macOS":
                                PlayAudioMacOS(audioPath);
                                break;
                            case "Linux":
                                PlayAudioLinux(audioPath);
                                break;
                            case "Windows":
                                PlayAudioWindows(audioPath);
                                break;
                            default:
                                Console.WriteLine($"🔇 Sistema operacional não suportado para áudio: {os}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️  Erro ao tocar áudio: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Erro geral no sistema de áudio: {ex.Message}");
            }
        }

        /// <summary>
        /// Toca áudio no macOS usando afplay
        /// </summary>
        private static void PlayAudioMacOS(string audioPath)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "afplay",
                Arguments = $"\"{audioPath}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = Process.Start(processInfo);
            if (process != null)
            {
                AddActiveProcess(process);
                process.WaitForExit();
                RemoveActiveProcess(process);
                process.Dispose();
            }
        }

        /// <summary>
        /// Toca áudio no Linux usando paplay ou aplay
        /// </summary>
        private static void PlayAudioLinux(string audioPath)
        {
            // Tenta paplay primeiro (PulseAudio)
            if (IsCommandAvailable("paplay"))
            {
                ExecuteAudioCommand("paplay", $"\"{audioPath}\"");
                return;
            }

            // Fallback para aplay (ALSA)
            if (IsCommandAvailable("aplay"))
            {
                ExecuteAudioCommand("aplay", $"\"{audioPath}\"");
                return;
            }

            // Fallback para ffplay (FFmpeg)
            if (IsCommandAvailable("ffplay"))
            {
                ExecuteAudioCommand("ffplay", $"-nodisp -autoexit \"{audioPath}\"");
                return;
            }

            Console.WriteLine("🔇 Nenhum player de áudio encontrado no Linux. Instale pulseaudio, alsa-utils ou ffmpeg.");
        }

        /// <summary>
        /// Toca áudio no Windows usando SoundPlayer
        /// </summary>
        private static void PlayAudioWindows(string audioPath)
        {
            try
            {
                // Usa o SoundPlayer do Windows
                var player = new System.Media.SoundPlayer(audioPath);
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Erro no Windows SoundPlayer: {ex.Message}");
            }
        }

        /// <summary>
        /// Executa um comando de áudio
        /// </summary>
        private static void ExecuteAudioCommand(string command, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = Process.Start(processInfo);
            if (process != null)
            {
                AddActiveProcess(process);
                process.WaitForExit();
                RemoveActiveProcess(process);
                process.Dispose();
            }
        }

        /// <summary>
        /// Verifica se um comando está disponível no sistema
        /// </summary>
        private static bool IsCommandAvailable(string command)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "which",
                    Arguments = command,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                using (var process = Process.Start(processInfo))
                {
                    process?.WaitForExit();
                    return process?.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Toca áudio de forma síncrona (para compatibilidade)
        /// </summary>
        public static void PlayAudio(string audioFile)
        {
            PlayAudioAsync(audioFile).Wait();
        }

        /// <summary>
        /// Toca áudio em uma thread separada (não bloqueia)
        /// </summary>
        public static void PlayAudioInBackground(string audioFile)
        {
            Task.Run(() => PlayAudioAsync(audioFile));
        }

        /// <summary>
        /// Habilita ou desabilita o sistema de áudio
        /// </summary>
        public static void SetAudioEnabled(bool enabled)
        {
            _audioEnabled = enabled;
            Console.WriteLine($"🔊 Áudio {(enabled ? "habilitado" : "desabilitado")}");
        }

        /// <summary>
        /// Obtém o status do sistema de áudio
        /// </summary>
        public static bool IsAudioEnabled()
        {
            return _audioEnabled;
        }

        /// <summary>
        /// Exibe informações do sistema de áudio
        /// </summary>
        public static void ShowAudioInfo()
        {
            string os = GetOperatingSystem();
            Console.WriteLine($"🎵 Sistema de Áudio Intergalactic Horse Racing");
            Console.WriteLine($"   Sistema Operacional: {os}");
            Console.WriteLine($"   Status: {(_audioEnabled ? "Habilitado" : "Desabilitado")}");
            
            switch (os)
            {
                case "macOS":
                    Console.WriteLine($"   Player: afplay (nativo do macOS)");
                    break;
                case "Linux":
                    Console.WriteLine($"   Player: paplay/aplay/ffplay (autodetectado)");
                    break;
                case "Windows":
                    Console.WriteLine($"   Player: System.Media.SoundPlayer");
                    break;
            }
        }
    }
} 