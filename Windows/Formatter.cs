using System;
using System.Globalization;
using System.Text;

namespace Backup.Utils {

    /// <summary>
    /// Classe para a formatação de dados e conversão de um formato para 
    /// outro.
    /// </summary>
    public class Formatter {


        /// <summary>
        /// Formatar uma data para o padrão dd/MM/aaaa hh:MM:ss.
        /// </summary>
        /// <param name="dateTime">Data a ser formatada.</param>
        /// <returns>Data formatada para o padrão dd/MM/aaaa hh:MM:ss.</returns>
        public static string FormatDate(DateTime dateTime) {
            StringBuilder sb = new StringBuilder();
            int day = dateTime.Day, month = dateTime.Month, year = dateTime.Year,
            hour = dateTime.Hour, minute = dateTime.Minute, second = dateTime.Second;
            sb.Append(day < 10 ? "0" + day.ToString() : day.ToString());
            sb.Append(month < 10 ? "0" + month.ToString() : month.ToString());
            sb.Append(year.ToString());
            sb.Append(hour < 10 ? "0" + hour.ToString() : hour.ToString());
            sb.Append(minute < 10 ? "0" + minute.ToString() : minute.ToString());
            sb.Append(second < 10 ? "0" + second.ToString() : second.ToString());
            return sb.ToString();
        }


        /// <summary>
        /// Converter uma string no padrão dd/MM/aaaa hh:MM:ss para uma data.
        /// </summary>
        /// <param name="dateStr">String a ser convertida</param>
        /// <returns>Data relativa.</returns>
        public static DateTime FormatDate(string dateStr) {
            int day = int.Parse(dateStr.Substring(0, 2));
            int month = int.Parse(dateStr.Substring(2, 2));
            int year = int.Parse(dateStr.Substring(4, 4));
            int hour = int.Parse(dateStr.Substring(8, 2));
            int minute = int.Parse(dateStr.Substring(10, 2));
            int second = int.Parse(dateStr.Substring(12, 2));
            return new DateTime(year, month, day, hour, minute, second);
        }


        /// <summary>
        /// Formatar o tamanho de um arquivo em byte, kilobyte, megabyte,
        /// gigabyte, etc.
        /// </summary>
        /// <param name="size">Tamanho do arquivo.</param>
        /// <returns></returns>
        public static string FormatSize(long  size) {
            double d;
            String m;
            if (size < 1024) {
                d = size;
                m = "B";
            } else if (size >= 1024 && size < 1048576) {
                d = size / 1024F;
                m = "KB";
            } else if (size >= 1048576 && size < 1073741824L) {
                d = size / 1048576F;
                m = "MB";
            } else if (size >= 1073741824L && size < 1099511627776L) {
                d = size / 1073741824F;
                m = "GB";
            } else {
                d = size / 1099511627776F;
                m = "TB";
            }
            return d.ToString("F", CultureInfo.InvariantCulture) + " " + m;
        }


        /// <summary>
        /// Formatar um inteiro em string com um número fixo de casas decimais.
        /// </summary>
        /// <param name="value">Número a ser formatado.</param>
        /// <param name="size">Número fixo de casas decimais.</param>
        /// <returns></returns>
        public static string FormatInt(int value, int size) {
            string result;
            string valueStr = value.ToString();
            int valueSize = valueStr.Length;
            if (valueSize < size) {
                string zeroFill = "";
                for (int i = valueSize + 1; i <= size; i++) {
                    zeroFill += "0";
                }
                result = zeroFill + valueStr;
            } else {
                result = valueStr;
            }
            return result;
        }


    }

}
