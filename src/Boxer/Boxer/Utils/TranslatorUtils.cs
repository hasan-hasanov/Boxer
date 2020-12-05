using ScoopBox.Translators;
using ScoopBox.Translators.Bat;
using ScoopBox.Translators.Cmd;
using ScoopBox.Translators.Powershell;
using System;
using System.Collections.Generic;
using System.IO;

namespace Boxer.Utils
{
    public static class TranslatorUtils
    {
        private static readonly Dictionary<string, IPowershellTranslator> _translatorFactory;

        static TranslatorUtils()
        {
            _translatorFactory = new Dictionary<string, IPowershellTranslator>()
            {
                { ".ps1", new PowershellTranslator() },
                { ".bat", new BatTranslator() },
                { ".cmd", new CmdTranslator() }
            };
        }

        public static IPowershellTranslator GetTranslatorByExtensionType(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            if (_translatorFactory.ContainsKey(extension))
            {
                return _translatorFactory[extension];
            }

            throw new NotSupportedException($"File type {extension} not supported!");
        }
    }
}
