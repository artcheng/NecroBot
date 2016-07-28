using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoGo.NecroBot.Logic.Logging;
using System.Drawing;
using PoGo.NecroBot.Logic.State;

namespace PoGo.NecroBot.GUI
{
    class GUILogger : ILogger
    {
        private readonly LogLevel _maxLogLevel;
        private readonly GUI _GUI;
        private ISession _session;

        /// <summary>
        ///     To create a ConsoleLogger, we must define a maximum log level.
        ///     All levels above won't be logged.
        /// </summary>
        /// <param name="maxLogLevel"></param>
        public GUILogger(LogLevel maxLogLevel, GUI gui)
        {
            _maxLogLevel = maxLogLevel;
            _GUI = gui;
        }

        /// <summary>
        ///     Log a specific message by LogLevel. Won't log if the LogLevel is greater than the maxLogLevel set.
        /// </summary>
        /// <param name="message">The message to log. The current time will be prepended.</param>
        /// <param name="level">Optional. Default <see cref="LogLevel.Info" />.</param>
        /// <param name="color">Optional. Default is auotmatic</param>
        public void Write(string message, LogLevel level = LogLevel.Info, ConsoleColor color = ConsoleColor.Black)
        {
            //Remember to change to a font that supports your language, otherwise it'll still show as ???
            //Console.OutputEncoding = Encoding.Unicode;
            if (level > _maxLogLevel)
                return;

            Color messageColor;

            switch (level)
            {
                case LogLevel.Error:
                    messageColor = Color.Red;
                    break;
                case LogLevel.Warning:
                    messageColor = Color.Orange;
                    break;
                case LogLevel.Info:
                    messageColor = Color.DarkCyan;
                    break;
                case LogLevel.Pokestop:
                    messageColor = Color.Cyan;
                    break;
                case LogLevel.Farming:
                    messageColor = Color.Magenta;
                    break;
                case LogLevel.Recycling:
                    messageColor = Color.DarkMagenta;
                    break;
                case LogLevel.Caught:
                    messageColor = Color.Green;
                    break;
                case LogLevel.Transfer:
                    messageColor = Color.DarkGreen;
                    break;
                case LogLevel.Evolve:
                    messageColor = Color.Yellow;
                    break;
                case LogLevel.Berry:
                    messageColor = Color.LightGoldenrodYellow;
                    break;
                case LogLevel.Egg:
                    messageColor = Color.LightGoldenrodYellow;
                    break;
                case LogLevel.Debug:
                    messageColor = Color.Gray;
                    break;
                default:
                    messageColor = Color.White;
                    break;
            }

            _GUI.UpdateLog(level, message, messageColor);
        }

        public void SetSession(ISession session)
        {
            _session = session;
        }
    }
}
