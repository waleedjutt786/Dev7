//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Net.Mail;
//using System.Text.RegularExpressions;
//using Microsoft.Win32;
//using dev7.EMS.Model.Common;
//using System.Drawing;
//using System.Web;
//using System.Web.Mvc;
//using dev7.EMS.Framework.Model;

//namespace dev7.EMS.Framework
//{
//    public static class Extensions
//    {

//        public static string MinifyHtml(this string str)
//        {
//            str = Regex.Replace(str, @"\n|\t", " ");
//            str = Regex.Replace(str, @">\s+<", "><").Trim();
//            str = Regex.Replace(str, @"\s{2,}", " ");
//            return str;
//        }
//        public static string ConvertDateCalendar(this DateTime DateConv, string Calendar, string DateLangCulture)
//        {
//            DateTimeFormatInfo DTFormat;
//            DateLangCulture = DateLangCulture.ToLower();
//            /// We can't have the hijri date writen in English. We will get a runtime error

//            if (Calendar == "Hijri" && DateLangCulture.StartsWith("en-"))
//            {
//                DateLangCulture = "ar-sa";
//            }

//            /// Set the date time format to the given culture
//            DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;

//            /// Set the calendar property of the date time format to the given calendar
//            switch (Calendar)
//            {
//                case "Hijri":
//                    DTFormat.Calendar = new System.Globalization.HijriCalendar();
//                    break;

//                case "Gregorian":
//                    DTFormat.Calendar = new System.Globalization.GregorianCalendar();
//                    break;

//                default:
//                    return "";
//            }

//            /// We format the date structure to whatever we want
//            DTFormat.ShortDatePattern = "dd/MM/yyyy";
//            //DTFormat.ShortDatePattern = "yyyy/MM/dd";
//            return (DateConv.Date.ToString("f", DTFormat));
//        }
//        public static Words ToWords(this decimal num)
//        {
//            Words wd = new Words(num);

//            var toWd = new ToWord(num, new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
//            wd.EnglishWord = toWd.ConvertToEnglish();
//            wd.ArabicWord = toWd.ConvertToArabic();

//            return wd;
//        }

//        /// <summary>
//        ///     Converts a string value to enum.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="value">The value.</param>
//        /// <returns></returns>
//        public static T ToEnum<T>(this string value)
//        {
//            return (T)Enum.Parse(typeof(T), value, true);
//        }
//        public static string ToDescription(this Enum en)
//        {
//            var type = en.GetType();

//            var memInfo = type.GetMember(en.ToString());
//            if (memInfo.Length <= 0) return en.ToString();

//            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

//            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : en.ToString();
//        }
//        public static bool IsValidEmail(this string email)
//        {
//            try
//            {
//                var addr = new MailAddress(email);
//                return addr.Address == email;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public static bool IsBase64String3(this string s)
//        {
//            if (string.IsNullOrWhiteSpace(s))
//                return false;

//            s = s.Trim();
//            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

//        }
//        public static bool IsBase64String2(this string value)
//        {
//            var _base64Characters = new HashSet<char>() {
//                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
//                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
//                'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
//                'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/',
//                '='};

//            if (string.IsNullOrEmpty(value))
//            {
//                return false;
//            }
//            else if (value.Any(c => !_base64Characters.Contains(c)))
//            {
//                return false;
//            }

//            try
//            {
//                Convert.FromBase64String(value);
//                return true;
//            }
//            catch (FormatException)
//            {
//                return false;
//            }
//        }
//        public static string SperateEmailHost(this string email)
//        {
//            var addr = new MailAddress(email);
//            return addr.Host;
//        }
//        public static string RandomString(this Random random, int length)
//        {
//            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
//            return new string(Enumerable.Repeat(chars, length)
//              .Select(s => s[random.Next(s.Length)]).ToArray());
//        }

//        public static string RandomLetterString(this Random random, int length)
//        {
//            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//            return new string(Enumerable.Repeat(chars, length)
//              .Select(s => s[random.Next(s.Length)]).ToArray());
//        }
//        public static System.Drawing.Image Base64ToImage(this string base64image)
//        {
//            byte[] bytes = Convert.FromBase64String(base64image);
//            var ms = new MemoryStream(bytes, 0, bytes.Length);
//            ms.Write(bytes, 0, bytes.Length);
//            var image = System.Drawing.Image.FromStream(ms, true);
//            return image;
//        }

//        /// <summary>
//        /// Converts any list in to Lookup List. Which will have two fields i.e id and Description
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="items">The items.</param>
//        /// <param name="text">The text it must be a string value will be used as Description</param>
//        /// <param name="value">The value must be an integer value, and will be use as id.</param>
//        /// <returns></returns>
//        public static IList<LookUpMD> ToLookupList<T>(this IList<T> items,
//                       Func<T, string> text, Func<T, int> value)
//        {
//            if (items.Equals(default(IList<T>))) return new List<LookUpMD>();

//            return items.Select(p => new LookUpMD
//            {
//                Name = text.Invoke(p),
//                Id = value.Invoke(p)
//            }).ToList();
//        }

//        public static bool IsBase64String(this string s)
//        {
//            s = s.Trim();
//            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

//        }

//        public static string GetBase64ContentType(this string image)
//        {
//            int index = image.IndexOf(";", StringComparison.OrdinalIgnoreCase);
//            string str = string.Empty;
//            if (index >= 0)
//            {
//                var dataLabel = image.Substring(0, index);
//                str = dataLabel.Split(':').Last();
//            }

//            return str;
//        }
//        public static string GetDefaultExtension(this string mimeType)
//        {
//            string result;
//            RegistryKey key;
//            object value;

//            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
//            value = key != null ? key.GetValue("Extension", null) : null;
//            result = value != null ? value.ToString() : string.Empty;

//            return result;
//        }

//        public static string GetBase64FileContent(this string image)
//        {
//            var startIndex = 0;
//            if (image.IndexOf("base64,", StringComparison.Ordinal) > 0)
//                startIndex = image.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;
//            return startIndex == 0 ? image : image.Substring(startIndex);
//        }

//        public static string GetExtensionType(this string mime)
//        {
//            if (string.IsNullOrEmpty(mime)) return string.Empty;

//            Lazy<IDictionary<string, string>> _mappings = new Lazy<IDictionary<string, string>>(BuildMappings);
//            if (string.IsNullOrWhiteSpace(mime))
//            {
//                throw new ArgumentNullException("mime");
//            }
//            string extension;

//            //return _mappings.Value.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
//            return _mappings.Value.TryGetValue(mime, out extension) ? extension : "";
//        }
//        public static string GetMimeType(string extension)
//        {
//            Lazy<IDictionary<string, string>> _mappings = new Lazy<IDictionary<string, string>>(BuildMappings);
//            if (extension == null)
//            {
//                throw new ArgumentNullException("extension");
//            }

//            if (!extension.StartsWith("."))
//            {
//                extension = "." + extension;
//            }

//            string mime;

//            //return _mappings.Value.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
//            return _mappings.Value.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
//        }
//        //MIME types
//        private static IDictionary<string, string> BuildMappings()
//        {
//            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
//                {

//                    #region Big freaking list of mime types

//                    // maps both ways,
//                    // extension -> mime type
//                    //   and
//                    // mime type -> extension
//                    //
//                    // any mime types on left side not pre-loaded on right side, are added automatically
//                    // some mime types can map to multiple extensions, so to get a deterministic mapping,
//                    // add those to the dictionary specifcially
//                    //
//                    // combination of values from Windows 7 Registry and 
//                    // from C:\Windows\System32\inetsrv\config\applicationHost.config
//                    // some added, including .7z and .dat
//                    //
//                    // Some added based on http://www.iana.org/assignments/media-types/media-types.xhtml
//                    // which lists mime types, but not extensions
//                    //
//                    {".323", "text/h323"},
//                    {".3g2", "video/3gpp2"},
//                    {".3gp", "video/3gpp"},
//                    {".3gp2", "video/3gpp2"},
//                    {".3gpp", "video/3gpp"},
//                    {".7z", "application/x-7z-compressed"},
//                    {".aa", "audio/audible"},
//                    {".AAC", "audio/aac"},
//                    {".aaf", "application/octet-stream"},
//                    {".aax", "audio/vnd.audible.aax"},
//                    {".ac3", "audio/ac3"},
//                    {".aca", "application/octet-stream"},
//                    {".accda", "application/msaccess.addin"},
//                    {".accdb", "application/msaccess"},
//                    {".accdc", "application/msaccess.cab"},
//                    {".accde", "application/msaccess"},
//                    {".accdr", "application/msaccess.runtime"},
//                    {".accdt", "application/msaccess"},
//                    {".accdw", "application/msaccess.webapplication"},
//                    {".accft", "application/msaccess.ftemplate"},
//                    {".acx", "application/internet-property-stream"},
//                    {".AddIn", "text/xml"},
//                    {".ade", "application/msaccess"},
//                    {".adobebridge", "application/x-bridge-url"},
//                    {".adp", "application/msaccess"},
//                    {".ADT", "audio/vnd.dlna.adts"},
//                    {".ADTS", "audio/aac"},
//                    {".afm", "application/octet-stream"},
//                    {".ai", "application/postscript"},
//                    {".aif", "audio/aiff"},
//                    {".aifc", "audio/aiff"},
//                    {".aiff", "audio/aiff"},
//                    {".air", "application/vnd.adobe.air-application-installer-package+zip"},
//                    {".amc", "application/mpeg"},
//                    {".anx", "application/annodex"},
//                    {".apk", "application/vnd.android.package-archive"},
//                    {".application", "application/x-ms-application"},
//                    {".art", "image/x-jg"},
//                    {".asa", "application/xml"},
//                    {".asax", "application/xml"},
//                    {".ascx", "application/xml"},
//                    {".asd", "application/octet-stream"},
//                    {".asf", "video/x-ms-asf"},
//                    {".ashx", "application/xml"},
//                    {".asi", "application/octet-stream"},
//                    {".asm", "text/plain"},
//                    {".asmx", "application/xml"},
//                    {".aspx", "application/xml"},
//                    {".asr", "video/x-ms-asf"},
//                    {".asx", "video/x-ms-asf"},
//                    {".atom", "application/atom+xml"},
//                    {".au", "audio/basic"},
//                    {".avi", "video/x-msvideo"},
//                    {".axa", "audio/annodex"},
//                    {".axs", "application/olescript"},
//                    {".axv", "video/annodex"},
//                    {".bas", "text/plain"},
//                    {".bcpio", "application/x-bcpio"},
//                    {".bin", "application/octet-stream"},
//                    {".bmp", "image/bmp"},
//                    {".c", "text/plain"},
//                    {".cab", "application/octet-stream"},
//                    {".caf", "audio/x-caf"},
//                    {".calx", "application/vnd.ms-office.calx"},
//                    {".cat", "application/vnd.ms-pki.seccat"},
//                    {".cc", "text/plain"},
//                    {".cd", "text/plain"},
//                    {".cdda", "audio/aiff"},
//                    {".cdf", "application/x-cdf"},
//                    {".cer", "application/x-x509-ca-cert"},
//                    {".cfg", "text/plain"},
//                    {".chm", "application/octet-stream"},
//                    {".class", "application/x-java-applet"},
//                    {".clp", "application/x-msclip"},
//                    {".cmd", "text/plain"},
//                    {".cmx", "image/x-cmx"},
//                    {".cnf", "text/plain"},
//                    {".cod", "image/cis-cod"},
//                    {".config", "application/xml"},
//                    {".contact", "text/x-ms-contact"},
//                    {".coverage", "application/xml"},
//                    {".cpio", "application/x-cpio"},
//                    {".cpp", "text/plain"},
//                    {".crd", "application/x-mscardfile"},
//                    {".crl", "application/pkix-crl"},
//                    {".crt", "application/x-x509-ca-cert"},
//                    {".cs", "text/plain"},
//                    {".csdproj", "text/plain"},
//                    {".csh", "application/x-csh"},
//                    {".csproj", "text/plain"},
//                    {".css", "text/css"},
//                    {".csv", "text/csv"},
//                    {".cur", "application/octet-stream"},
//                    {".cxx", "text/plain"},
//                    {".dat", "application/octet-stream"},
//                    {".datasource", "application/xml"},
//                    {".dbproj", "text/plain"},
//                    {".dcr", "application/x-director"},
//                    {".def", "text/plain"},
//                    {".deploy", "application/octet-stream"},
//                    {".der", "application/x-x509-ca-cert"},
//                    {".dgml", "application/xml"},
//                    {".dib", "image/bmp"},
//                    {".dif", "video/x-dv"},
//                    {".dir", "application/x-director"},
//                    {".disco", "text/xml"},
//                    {".divx", "video/divx"},
//                    {".dll", "application/x-msdownload"},
//                    {".dll.config", "text/xml"},
//                    {".dlm", "text/dlm"},
//                    {".doc", "application/msword"},
//                    {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
//                    {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
//                    {".dot", "application/msword"},
//                    {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
//                    {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
//                    {".dsp", "application/octet-stream"},
//                    {".dsw", "text/plain"},
//                    {".dtd", "text/xml"},
//                    {".dtsConfig", "text/xml"},
//                    {".dv", "video/x-dv"},
//                    {".dvi", "application/x-dvi"},
//                    {".dwf", "drawing/x-dwf"},
//                    {".dwp", "application/octet-stream"},
//                    {".dxr", "application/x-director"},
//                    {".eml", "message/rfc822"},
//                    {".emz", "application/octet-stream"},
//                    {".eot", "application/vnd.ms-fontobject"},
//                    {".eps", "application/postscript"},
//                    {".etl", "application/etl"},
//                    {".etx", "text/x-setext"},
//                    {".evy", "application/envoy"},
//                    {".exe", "application/octet-stream"},
//                    {".exe.config", "text/xml"},
//                    {".fdf", "application/vnd.fdf"},
//                    {".fif", "application/fractals"},
//                    {".filters", "application/xml"},
//                    {".fla", "application/octet-stream"},
//                    {".flac", "audio/flac"},
//                    {".flr", "x-world/x-vrml"},
//                    {".flv", "video/x-flv"},
//                    {".fsscript", "application/fsharp-script"},
//                    {".fsx", "application/fsharp-script"},
//                    {".generictest", "application/xml"},
//                    {".gif", "image/gif"},
//                    {".gpx", "application/gpx+xml"},
//                    {".group", "text/x-ms-group"},
//                    {".gsm", "audio/x-gsm"},
//                    {".gtar", "application/x-gtar"},
//                    {".gz", "application/x-gzip"},
//                    {".h", "text/plain"},
//                    {".hdf", "application/x-hdf"},
//                    {".hdml", "text/x-hdml"},
//                    {".hhc", "application/x-oleobject"},
//                    {".hhk", "application/octet-stream"},
//                    {".hhp", "application/octet-stream"},
//                    {".hlp", "application/winhlp"},
//                    {".hpp", "text/plain"},
//                    {".hqx", "application/mac-binhex40"},
//                    {".hta", "application/hta"},
//                    {".htc", "text/x-component"},
//                    {".htm", "text/html"},
//                    {".html", "text/html"},
//                    {".htt", "text/webviewhtml"},
//                    {".hxa", "application/xml"},
//                    {".hxc", "application/xml"},
//                    {".hxd", "application/octet-stream"},
//                    {".hxe", "application/xml"},
//                    {".hxf", "application/xml"},
//                    {".hxh", "application/octet-stream"},
//                    {".hxi", "application/octet-stream"},
//                    {".hxk", "application/xml"},
//                    {".hxq", "application/octet-stream"},
//                    {".hxr", "application/octet-stream"},
//                    {".hxs", "application/octet-stream"},
//                    {".hxt", "text/html"},
//                    {".hxv", "application/xml"},
//                    {".hxw", "application/octet-stream"},
//                    {".hxx", "text/plain"},
//                    {".i", "text/plain"},
//                    {".ico", "image/x-icon"},
//                    {".ics", "application/octet-stream"},
//                    {".idl", "text/plain"},
//                    {".ief", "image/ief"},
//                    {".iii", "application/x-iphone"},
//                    {".inc", "text/plain"},
//                    {".inf", "application/octet-stream"},
//                    {".ini", "text/plain"},
//                    {".inl", "text/plain"},
//                    {".ins", "application/x-internet-signup"},
//                    {".ipa", "application/x-itunes-ipa"},
//                    {".ipg", "application/x-itunes-ipg"},
//                    {".ipproj", "text/plain"},
//                    {".ipsw", "application/x-itunes-ipsw"},
//                    {".iqy", "text/x-ms-iqy"},
//                    {".isp", "application/x-internet-signup"},
//                    {".ite", "application/x-itunes-ite"},
//                    {".itlp", "application/x-itunes-itlp"},
//                    {".itms", "application/x-itunes-itms"},
//                    {".itpc", "application/x-itunes-itpc"},
//                    {".IVF", "video/x-ivf"},
//                    {".jar", "application/java-archive"},
//                    {".java", "application/octet-stream"},
//                    {".jck", "application/liquidmotion"},
//                    {".jcz", "application/liquidmotion"},
//                    {".jfif", "image/pjpeg"},
//                    {".jnlp", "application/x-java-jnlp-file"},
//                    {".jpb", "application/octet-stream"},
//                    {".jpe", "image/jpe"},
//                    {".jpeg", "image/jpeg"},
//                    {".jpg", "image/jpg"},
//                    {".js", "application/javascript"},
//                    {".json", "application/json"},
//                    {".jsx", "text/jscript"},
//                    {".jsxbin", "text/plain"},
//                    {".latex", "application/x-latex"},
//                    {".library-ms", "application/windows-library+xml"},
//                    {".lit", "application/x-ms-reader"},
//                    {".loadtest", "application/xml"},
//                    {".lpk", "application/octet-stream"},
//                    {".lsf", "video/x-la-asf"},
//                    {".lst", "text/plain"},
//                    {".lsx", "video/x-la-asf"},
//                    {".lzh", "application/octet-stream"},
//                    {".m13", "application/x-msmediaview"},
//                    {".m14", "application/x-msmediaview"},
//                    {".m1v", "video/mpeg"},
//                    {".m2t", "video/vnd.dlna.mpeg-tts"},
//                    {".m2ts", "video/vnd.dlna.mpeg-tts"},
//                    {".m2v", "video/mpeg"},
//                    {".m3u", "audio/x-mpegurl"},
//                    {".m3u8", "audio/x-mpegurl"},
//                    {".m4a", "audio/m4a"},
//                    {".m4b", "audio/m4b"},
//                    {".m4p", "audio/m4p"},
//                    {".m4r", "audio/x-m4r"},
//                    {".m4v", "video/x-m4v"},
//                    {".mac", "image/x-macpaint"},
//                    {".mak", "text/plain"},
//                    {".man", "application/x-troff-man"},
//                    {".manifest", "application/x-ms-manifest"},
//                    {".map", "text/plain"},
//                    {".master", "application/xml"},
//                    {".mda", "application/msaccess"},
//                    {".mdb", "application/x-msaccess"},
//                    {".mde", "application/msaccess"},
//                    {".mdp", "application/octet-stream"},
//                    {".me", "application/x-troff-me"},
//                    {".mfp", "application/x-shockwave-flash"},
//                    {".mht", "message/rfc822"},
//                    {".mhtml", "message/rfc822"},
//                    {".mid", "audio/mid"},
//                    {".midi", "audio/mid"},
//                    {".mix", "application/octet-stream"},
//                    {".mk", "text/plain"},
//                    {".mmf", "application/x-smaf"},
//                    {".mno", "text/xml"},
//                    {".mny", "application/x-msmoney"},
//                    {".mod", "video/mpeg"},
//                    {".mov", "video/quicktime"},
//                    {".movie", "video/x-sgi-movie"},
//                    {".mp2", "video/mpeg"},
//                    {".mp2v", "video/mpeg"},
//                    {".mp3", "audio/mpeg"},
//                    {".mp4", "video/mp4"},
//                    {".mp4v", "video/mp4"},
//                    {".mpa", "video/mpeg"},
//                    {".mpe", "video/mpeg"},
//                    {".mpeg", "video/mpeg"},
//                    {".mpf", "application/vnd.ms-mediapackage"},
//                    {".mpg", "video/mpeg"},
//                    {".mpp", "application/vnd.ms-project"},
//                    {".mpv2", "video/mpeg"},
//                    {".mqv", "video/quicktime"},
//                    {".ms", "application/x-troff-ms"},
//                    {".msi", "application/octet-stream"},
//                    {".mso", "application/octet-stream"},
//                    {".mts", "video/vnd.dlna.mpeg-tts"},
//                    {".mtx", "application/xml"},
//                    {".mvb", "application/x-msmediaview"},
//                    {".mvc", "application/x-miva-compiled"},
//                    {".mxp", "application/x-mmxp"},
//                    {".nc", "application/x-netcdf"},
//                    {".nsc", "video/x-ms-asf"},
//                    {".nws", "message/rfc822"},
//                    {".ocx", "application/octet-stream"},
//                    {".oda", "application/oda"},
//                    {".odb", "application/vnd.oasis.opendocument.database"},
//                    {".odc", "application/vnd.oasis.opendocument.chart"},
//                    {".odf", "application/vnd.oasis.opendocument.formula"},
//                    {".odg", "application/vnd.oasis.opendocument.graphics"},
//                    {".odh", "text/plain"},
//                    {".odi", "application/vnd.oasis.opendocument.image"},
//                    {".odl", "text/plain"},
//                    {".odm", "application/vnd.oasis.opendocument.text-master"},
//                    {".odp", "application/vnd.oasis.opendocument.presentation"},
//                    {".ods", "application/vnd.oasis.opendocument.spreadsheet"},
//                    {".odt", "application/vnd.oasis.opendocument.text"},
//                    {".oga", "audio/ogg"},
//                    {".ogg", "audio/ogg"},
//                    {".ogv", "video/ogg"},
//                    {".ogx", "application/ogg"},
//                    {".one", "application/onenote"},
//                    {".onea", "application/onenote"},
//                    {".onepkg", "application/onenote"},
//                    {".onetmp", "application/onenote"},
//                    {".onetoc", "application/onenote"},
//                    {".onetoc2", "application/onenote"},
//                    {".opus", "audio/ogg"},
//                    {".orderedtest", "application/xml"},
//                    {".osdx", "application/opensearchdescription+xml"},
//                    {".otf", "application/font-sfnt"},
//                    {".otg", "application/vnd.oasis.opendocument.graphics-template"},
//                    {".oth", "application/vnd.oasis.opendocument.text-web"},
//                    {".otp", "application/vnd.oasis.opendocument.presentation-template"},
//                    {".ots", "application/vnd.oasis.opendocument.spreadsheet-template"},
//                    {".ott", "application/vnd.oasis.opendocument.text-template"},
//                    {".oxt", "application/vnd.openofficeorg.extension"},
//                    {".p10", "application/pkcs10"},
//                    {".p12", "application/x-pkcs12"},
//                    {".p7b", "application/x-pkcs7-certificates"},
//                    {".p7c", "application/pkcs7-mime"},
//                    {".p7m", "application/pkcs7-mime"},
//                    {".p7r", "application/x-pkcs7-certreqresp"},
//                    {".p7s", "application/pkcs7-signature"},
//                    {".pbm", "image/x-portable-bitmap"},
//                    {".pcast", "application/x-podcast"},
//                    {".pct", "image/pict"},
//                    {".pcx", "application/octet-stream"},
//                    {".pcz", "application/octet-stream"},
//                    {".pdf", "application/pdf"},
//                    {".pfb", "application/octet-stream"},
//                    {".pfm", "application/octet-stream"},
//                    {".pfx", "application/x-pkcs12"},
//                    {".pgm", "image/x-portable-graymap"},
//                    {".pic", "image/pict"},
//                    {".pict", "image/pict"},
//                    {".pkgdef", "text/plain"},
//                    {".pkgundef", "text/plain"},
//                    {".pko", "application/vnd.ms-pki.pko"},
//                    {".pls", "audio/scpls"},
//                    {".pma", "application/x-perfmon"},
//                    {".pmc", "application/x-perfmon"},
//                    {".pml", "application/x-perfmon"},
//                    {".pmr", "application/x-perfmon"},
//                    {".pmw", "application/x-perfmon"},
//                    {".png", "image/png"},
//                    {".pnm", "image/x-portable-anymap"},
//                    {".pnt", "image/x-macpaint"},
//                    {".pntg", "image/x-macpaint"},
//                    {".pnz", "image/png"},
//                    {".pot", "application/vnd.ms-powerpoint"},
//                    {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
//                    {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
//                    {".ppa", "application/vnd.ms-powerpoint"},
//                    {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
//                    {".ppm", "image/x-portable-pixmap"},
//                    {".pps", "application/vnd.ms-powerpoint"},
//                    {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
//                    {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
//                    {".ppt", "application/vnd.ms-powerpoint"},
//                    {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
//                    {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
//                    {".prf", "application/pics-rules"},
//                    {".prm", "application/octet-stream"},
//                    {".prx", "application/octet-stream"},
//                    {".ps", "application/postscript"},
//                    {".psc1", "application/PowerShell"},
//                    {".psd", "application/octet-stream"},
//                    {".psess", "application/xml"},
//                    {".psm", "application/octet-stream"},
//                    {".psp", "application/octet-stream"},
//                    {".pub", "application/x-mspublisher"},
//                    {".pwz", "application/vnd.ms-powerpoint"},
//                    {".qht", "text/x-html-insertion"},
//                    {".qhtm", "text/x-html-insertion"},
//                    {".qt", "video/quicktime"},
//                    {".qti", "image/x-quicktime"},
//                    {".qtif", "image/x-quicktime"},
//                    {".qtl", "application/x-quicktimeplayer"},
//                    {".qxd", "application/octet-stream"},
//                    {".ra", "audio/x-pn-realaudio"},
//                    {".ram", "audio/x-pn-realaudio"},
//                    {".rar", "application/x-rar-compressed"},
//                    {".ras", "image/x-cmu-raster"},
//                    {".rat", "application/rat-file"},
//                    {".rc", "text/plain"},
//                    {".rc2", "text/plain"},
//                    {".rct", "text/plain"},
//                    {".rdlc", "application/xml"},
//                    {".reg", "text/plain"},
//                    {".resx", "application/xml"},
//                    {".rf", "image/vnd.rn-realflash"},
//                    {".rgb", "image/x-rgb"},
//                    {".rgs", "text/plain"},
//                    {".rm", "application/vnd.rn-realmedia"},
//                    {".rmi", "audio/mid"},
//                    {".rmp", "application/vnd.rn-rn_music_package"},
//                    {".roff", "application/x-troff"},
//                    {".rpm", "audio/x-pn-realaudio-plugin"},
//                    {".rqy", "text/x-ms-rqy"},
//                    {".rtf", "application/rtf"},
//                    {".rtx", "text/richtext"},
//                    {".ruleset", "application/xml"},
//                    {".s", "text/plain"},
//                    {".safariextz", "application/x-safari-safariextz"},
//                    {".scd", "application/x-msschedule"},
//                    {".scr", "text/plain"},
//                    {".sct", "text/scriptlet"},
//                    {".sd2", "audio/x-sd2"},
//                    {".sdp", "application/sdp"},
//                    {".sea", "application/octet-stream"},
//                    {".searchConnector-ms", "application/windows-search-connector+xml"},
//                    {".setpay", "application/set-payment-initiation"},
//                    {".setreg", "application/set-registration-initiation"},
//                    {".settings", "application/xml"},
//                    {".sgimb", "application/x-sgimb"},
//                    {".sgml", "text/sgml"},
//                    {".sh", "application/x-sh"},
//                    {".shar", "application/x-shar"},
//                    {".shtml", "text/html"},
//                    {".sit", "application/x-stuffit"},
//                    {".sitemap", "application/xml"},
//                    {".skin", "application/xml"},
//                    {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
//                    {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
//                    {".slk", "application/vnd.ms-excel"},
//                    {".sln", "text/plain"},
//                    {".slupkg-ms", "application/x-ms-license"},
//                    {".smd", "audio/x-smd"},
//                    {".smi", "application/octet-stream"},
//                    {".smx", "audio/x-smd"},
//                    {".smz", "audio/x-smd"},
//                    {".snd", "audio/basic"},
//                    {".snippet", "application/xml"},
//                    {".snp", "application/octet-stream"},
//                    {".sol", "text/plain"},
//                    {".sor", "text/plain"},
//                    {".spc", "application/x-pkcs7-certificates"},
//                    {".spl", "application/futuresplash"},
//                    {".spx", "audio/ogg"},
//                    {".src", "application/x-wais-source"},
//                    {".srf", "text/plain"},
//                    {".SSISDeploymentManifest", "text/xml"},
//                    {".ssm", "application/streamingmedia"},
//                    {".sst", "application/vnd.ms-pki.certstore"},
//                    {".stl", "application/vnd.ms-pki.stl"},
//                    {".sv4cpio", "application/x-sv4cpio"},
//                    {".sv4crc", "application/x-sv4crc"},
//                    {".svc", "application/xml"},
//                    {".svg", "image/svg+xml"},
//                    {".swf", "application/x-shockwave-flash"},
//                    {".step", "application/step"},
//                    {".stp", "application/step"},
//                    {".t", "application/x-troff"},
//                    {".tar", "application/x-tar"},
//                    {".tcl", "application/x-tcl"},
//                    {".testrunconfig", "application/xml"},
//                    {".testsettings", "application/xml"},
//                    {".tex", "application/x-tex"},
//                    {".texi", "application/x-texinfo"},
//                    {".texinfo", "application/x-texinfo"},
//                    {".tgz", "application/x-compressed"},
//                    {".thmx", "application/vnd.ms-officetheme"},
//                    {".thn", "application/octet-stream"},
//                    {".tif", "image/tiff"},
//                    {".tiff", "image/tiff"},
//                    {".tlh", "text/plain"},
//                    {".tli", "text/plain"},
//                    {".toc", "application/octet-stream"},
//                    {".tr", "application/x-troff"},
//                    {".trm", "application/x-msterminal"},
//                    {".trx", "application/xml"},
//                    {".ts", "video/vnd.dlna.mpeg-tts"},
//                    {".tsv", "text/tab-separated-values"},
//                    {".ttf", "application/font-sfnt"},
//                    {".tts", "video/vnd.dlna.mpeg-tts"},
//                    {".txt", "text/plain"},
//                    {".u32", "application/octet-stream"},
//                    {".uls", "text/iuls"},
//                    {".user", "text/plain"},
//                    {".ustar", "application/x-ustar"},
//                    {".vb", "text/plain"},
//                    {".vbdproj", "text/plain"},
//                    {".vbk", "video/mpeg"},
//                    {".vbproj", "text/plain"},
//                    {".vbs", "text/vbscript"},
//                    {".vcf", "text/x-vcard"},
//                    {".vcproj", "application/xml"},
//                    {".vcs", "text/plain"},
//                    {".vcxproj", "application/xml"},
//                    {".vddproj", "text/plain"},
//                    {".vdp", "text/plain"},
//                    {".vdproj", "text/plain"},
//                    {".vdx", "application/vnd.ms-visio.viewer"},
//                    {".vml", "text/xml"},
//                    {".vscontent", "application/xml"},
//                    {".vsct", "text/xml"},
//                    {".vsd", "application/vnd.visio"},
//                    {".vsi", "application/ms-vsi"},
//                    {".vsix", "application/vsix"},
//                    {".vsixlangpack", "text/xml"},
//                    {".vsixmanifest", "text/xml"},
//                    {".vsmdi", "application/xml"},
//                    {".vspscc", "text/plain"},
//                    {".vss", "application/vnd.visio"},
//                    {".vsscc", "text/plain"},
//                    {".vssettings", "text/xml"},
//                    {".vssscc", "text/plain"},
//                    {".vst", "application/vnd.visio"},
//                    {".vstemplate", "text/xml"},
//                    {".vsto", "application/x-ms-vsto"},
//                    {".vsw", "application/vnd.visio"},
//                    {".vsx", "application/vnd.visio"},
//                    {".vtx", "application/vnd.visio"},
//                    {".wav", "audio/wav"},
//                    {".wave", "audio/wav"},
//                    {".wax", "audio/x-ms-wax"},
//                    {".wbk", "application/msword"},
//                    {".wbmp", "image/vnd.wap.wbmp"},
//                    {".wcm", "application/vnd.ms-works"},
//                    {".wdb", "application/vnd.ms-works"},
//                    {".wdp", "image/vnd.ms-photo"},
//                    {".webarchive", "application/x-safari-webarchive"},
//                    {".webm", "video/webm"},
//                    {".webp", "image/webp"},
//                    /* https://en.wikipedia.org/wiki/WebP */
//                    {".webtest", "application/xml"},
//                    {".wiq", "application/xml"},
//                    {".wiz", "application/msword"},
//                    {".wks", "application/vnd.ms-works"},
//                    {".WLMP", "application/wlmoviemaker"},
//                    {".wlpginstall", "application/x-wlpg-detect"},
//                    {".wlpginstall3", "application/x-wlpg3-detect"},
//                    {".wm", "video/x-ms-wm"},
//                    {".wma", "audio/x-ms-wma"},
//                    {".wmd", "application/x-ms-wmd"},
//                    {".wmf", "application/x-msmetafile"},
//                    {".wml", "text/vnd.wap.wml"},
//                    {".wmlc", "application/vnd.wap.wmlc"},
//                    {".wmls", "text/vnd.wap.wmlscript"},
//                    {".wmlsc", "application/vnd.wap.wmlscriptc"},
//                    {".wmp", "video/x-ms-wmp"},
//                    {".wmv", "video/x-ms-wmv"},
//                    {".wmx", "video/x-ms-wmx"},
//                    {".wmz", "application/x-ms-wmz"},
//                    {".woff", "application/font-woff"},
//                    {".wpl", "application/vnd.ms-wpl"},
//                    {".wps", "application/vnd.ms-works"},
//                    {".wri", "application/x-mswrite"},
//                    {".wrl", "x-world/x-vrml"},
//                    {".wrz", "x-world/x-vrml"},
//                    {".wsc", "text/scriptlet"},
//                    {".wsdl", "text/xml"},
//                    {".wvx", "video/x-ms-wvx"},
//                    {".x", "application/directx"},
//                    {".xaf", "x-world/x-vrml"},
//                    {".xaml", "application/xaml+xml"},
//                    {".xap", "application/x-silverlight-app"},
//                    {".xbap", "application/x-ms-xbap"},
//                    {".xbm", "image/x-xbitmap"},
//                    {".xdr", "text/plain"},
//                    {".xht", "application/xhtml+xml"},
//                    {".xhtml", "application/xhtml+xml"},
//                    {".xla", "application/vnd.ms-excel"},
//                    {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
//                    {".xlc", "application/vnd.ms-excel"},
//                    {".xld", "application/vnd.ms-excel"},
//                    {".xlk", "application/vnd.ms-excel"},
//                    {".xll", "application/vnd.ms-excel"},
//                    {".xlm", "application/vnd.ms-excel"},
//                    {".xls", "application/vnd.ms-excel"},
//                    {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
//                    {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
//                    {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
//                    {".xlt", "application/vnd.ms-excel"},
//                    {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
//                    {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
//                    {".xlw", "application/vnd.ms-excel"},
//                    {".xml", "text/xml"},
//                    {".xmta", "application/xml"},
//                    {".xof", "x-world/x-vrml"},
//                    {".XOML", "text/plain"},
//                    {".xpm", "image/x-xpixmap"},
//                    {".xps", "application/vnd.ms-xpsdocument"},
//                    {".xrm-ms", "text/xml"},
//                    {".xsc", "application/xml"},
//                    {".xsd", "text/xml"},
//                    {".xsf", "text/xml"},
//                    {".xsl", "text/xml"},
//                    {".xslt", "text/xml"},
//                    {".xsn", "application/octet-stream"},
//                    {".xss", "application/xml"},
//                    {".xspf", "application/xspf+xml"},
//                    {".xtp", "application/octet-stream"},
//                    {".xwd", "image/x-xwindowdump"},
//                    {".z", "application/x-compress"},
//                    {".zip", "application/zip"},

//                    {"application/fsharp-script", ".fsx"},
//                    {"application/msaccess", ".adp"},
//                    {"application/msword", ".doc"},
//                    {"application/octet-stream", ".bin"},
//                    {"application/onenote", ".one"},
//                    {"application/postscript", ".eps"},
//                    {"application/step", ".step"},
//                    {"application/vnd.ms-excel", ".xls"},
//                    {"application/vnd.ms-powerpoint", ".ppt"},
//                    {"application/vnd.ms-works", ".wks"},
//                    {"application/vnd.visio", ".vsd"},
//                    {"application/x-director", ".dir"},
//                    {"application/x-shockwave-flash", ".swf"},
//                    {"application/x-x509-ca-cert", ".cer"},
//                    {"application/x-zip-compressed", ".zip"},
//                    {"application/xhtml+xml", ".xhtml"},
//                    {"application/xml", ".xml"},
//                    // anomoly, .xml -> text/xml, but application/xml -> many thingss, but all are xml, so safest is .xml
//                    {"audio/aac", ".AAC"},
//                    {"audio/aiff", ".aiff"},
//                    {"audio/basic", ".snd"},
//                    {"audio/mid", ".midi"},
//                    {"audio/wav", ".wav"},
//                    {"audio/x-m4a", ".m4a"},
//                    {"audio/x-mpegurl", ".m3u"},
//                    {"audio/x-pn-realaudio", ".ra"},
//                    {"audio/x-smd", ".smd"},
//                    {"image/bmp", ".bmp"},
//                    {"image/jpg", ".jpg"},
//                    {"image/jpe", ".jpe"},
//                    {"image/jpeg", ".jpeg"},
//                    {"image/pict", ".pic"},
//                    {"image/png", ".png"},
//                    {"image/tiff", ".tiff"},
//                    {"image/x-macpaint", ".mac"},
//                    {"image/x-quicktime", ".qti"},
//                    {"message/rfc822", ".eml"},
//                    {"text/html", ".html"},
//                    {"text/plain", ".txt"},
//                    {"text/scriptlet", ".wsc"},
//                    {"text/xml", ".xml"},
//                    {"video/3gpp", ".3gp"},
//                    {"video/3gpp2", ".3gp2"},
//                    {"video/mp4", ".mp4"},
//                    {"video/mpeg", ".mpg"},
//                    {"video/quicktime", ".mov"},
//                    {"video/vnd.dlna.mpeg-tts", ".m2t"},
//                    {"video/x-dv", ".dv"},
//                    {"video/x-la-asf", ".lsf"},
//                    {"video/x-ms-asf", ".asf"},
//                    {"x-world/x-vrml", ".xof"},

//                    #endregion

//                };

//            var cache = mappings.ToList(); // need ToList() to avoid modifying while still enumerating

//            foreach (var mapping in cache)
//            {
//                if (!mappings.ContainsKey(mapping.Value))
//                {
//                    mappings.Add(mapping.Value, mapping.Key);
//                }
//            }

//            return mappings;
//        }

//        public static string ToDateTime(this DateTime? d)
//        {
//            var retVal = string.Empty;
//            if (d.HasValue)
//                retVal = d.Value.ToString("MM/dd/yyyy HH:mm:ss");
//            return retVal;
//        }
//        public static string ToDateTime(this DateTime d)
//        {
//            return d.ToString("MM/dd/yyyy HH:mm:ss"); ;
//        }

//        public static bool SaveBase64ToFile(this string fileBytes, string path)
//        {
//            try
//            {
//                var bytes = Convert.FromBase64String(fileBytes);
//                File.WriteAllBytes(path, bytes);
//                return true;
//            }
//            catch (Exception ex)
//            { }
//            return false;
//        }

//        public static string ImageToBase64(this string imagePath)
//        {

//            using (Image image = Image.FromFile(imagePath))
//            {
//                using (MemoryStream m = new MemoryStream())
//                {
//                    image.Save(m, image.RawFormat);
//                    byte[] imageBytes = m.ToArray();

//                    // Convert byte[] to Base64 String
//                    string base64String = Convert.ToBase64String(imageBytes);
//                    return base64String;
//                }
//            }
//        }

//        public static void LogToFile(this String lines, string fileName)
//        {
//            // Write the string to a file.append mode is enabled so that the log
//            // lines get appended to  test.txt than wiping content and writing the log
//            //System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
//            StreamWriter file = new StreamWriter(fileName, true);
//            file.WriteLine(lines);
//            file.Close();
//        }

//        public static string GetUserImagePath(this string image, int id)
//        {
//            var userImagePath = string.Empty;
//            if (id == default(int))
//                return userImagePath;
//            const string mainPath = "//images//";
//            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~" + mainPath)))
//                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~" + mainPath));
//            string folderPath = $"{mainPath}{id}//";
//            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~" + folderPath)))
//                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~" + folderPath));
//            var fileName = DateTime.Now.ToFileTime();
//            if (!string.IsNullOrWhiteSpace(image))
//                userImagePath = image.GetBase64FileContent().IsBase64String2() ? folderPath + fileName + image.GetBase64ContentType().GetExtensionType() : userImagePath;
//            return userImagePath;
//        }

//        public static bool SaveImage(this string image, string path)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(path))
//                    return false;
//                if (string.IsNullOrWhiteSpace(image)) return false;
//                if (image.GetBase64FileContent().IsBase64String2())
//                    image.GetBase64FileContent().Base64ToImage().Save(HttpContext.Current.Server.MapPath("~" + path));

//            }
//            catch (Exception ex)
//            {

//            }

//            return true;
//        }

//        public static string CreateDirectory(this string path)
//        {
//            try
//            {
//                if (!Directory.Exists(path))
//                    Directory.CreateDirectory(path);
//            }
//            catch (Exception ex)
//            {

//                return null;
//            }

//            return Directory.Exists(path) ? path : null;
//        }

//        /// <summary>
//        ///To the select list.
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="items">The items.</param>
//        /// <param name="text">The text.</param>
//        /// <param name="value">The value.</param>
//        /// <returns></returns>
//        public static IList<SelectListItem> ToSelectList<T>(this List<T> items,
//            Func<T, string> text, Func<T, string> value = null)
//        {
//            if (items.Equals(default(IList<T>))) return new List<SelectListItem>();

//            return items.Select(p => new SelectListItem
//            {
//                Text = text.Invoke(p),
//                Value = value == null ? text.Invoke(p) : value.Invoke(p)
//            }).ToList();
//        }

//        /// <summary>
//        /// Converts any list in to Lookup List. Which will have two fields i.e Id and Description
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="items">The items.</param>
//        /// <param name="text">The text it must be a string value will be used as Description</param>
//        /// <param name="value">The value must be an integer value, and will be use as Id.</param>
//        /// <returns></returns>
//        public static IList<LookupList> ToLookupList<T>(this IList<T> items,
//            Func<T, string> text, Func<T, long> value)
//        {
//            if (items.Equals(default(IList<T>))) return new List<LookupList>();

//            return items.Select(p => new LookupList
//            {
//                Description = text.Invoke(p),
//                Id = value.Invoke(p)
//            }).ToList();
//        }
//    }
//}
