using System.Runtime.Serialization;

namespace Aliencube.ReCaptcha.Wrapper.Mvc
{
    /// <summary>
    /// This specifies the language code for reCaptcha control rendering.
    /// </summary>
    public enum WidgetLanguageCode
    {
        /// <summary>
        /// Identifies no language code is defined.
        /// </summary>
        Unknown = 0,

        ///
        /// Identifies the display language in Arabic.
        ///
        [EnumMember(Value = "ar")]
        Arabic = 1,

        ///
        /// Identifies the display language in Bulgarian.
        ///
        [EnumMember(Value = "bg")]
        Bulgarian = 2,

        ///
        /// Identifies the display language in Catalan.
        ///
        [EnumMember(Value = "ca")]
        Catalan = 3,

        ///
        /// Identifies the display language in Chinese (Simplified).
        ///
        [EnumMember(Value = "zh-CN")]
        Chinese_Simplified = 4,

        ///
        /// Identifies the display language in Chinese (Traditional).
        ///
        [EnumMember(Value = "zh-TW")]
        Chinese_Traditional = 5,

        ///
        /// Identifies the display language in Croatian.
        ///
        [EnumMember(Value = "hr")]
        Croatian = 6,

        ///
        /// Identifies the display language in Czech.
        ///
        [EnumMember(Value = "cs")]
        Czech = 7,

        ///
        /// Identifies the display language in Danish.
        ///
        [EnumMember(Value = "da")]
        Danish = 8,

        ///
        /// Identifies the display language in Dutch.
        ///
        [EnumMember(Value = "nl")]
        Dutch = 9,

        ///
        /// Identifies the display language in English (UK).
        ///
        [EnumMember(Value = "en-GB")]
        English_UK = 10,

        ///
        /// Identifies the display language in English (US).
        ///
        [EnumMember(Value = "en")]
        English_US = 11,

        ///
        /// Identifies the display language in Filipino.
        ///
        [EnumMember(Value = "fil")]
        Filipino = 12,

        ///
        /// Identifies the display language in Finnish.
        ///
        [EnumMember(Value = "fi")]
        Finnish = 13,

        ///
        /// Identifies the display language in French.
        ///
        [EnumMember(Value = "fr")]
        French = 14,

        ///
        /// Identifies the display language in French (Canadian).
        ///
        [EnumMember(Value = "fr-CA")]
        French_Canadian = 15,

        ///
        /// Identifies the display language in German.
        ///
        [EnumMember(Value = "de")]
        German = 16,

        ///
        /// Identifies the display language in German (Austria).
        ///
        [EnumMember(Value = "de-AT")]
        German_Austria = 17,

        ///
        /// Identifies the display language in German (Switzerland).
        ///
        [EnumMember(Value = "de-CH")]
        German_Switzerland = 18,

        ///
        /// Identifies the display language in Greek.
        ///
        [EnumMember(Value = "el")]
        Greek = 19,

        ///
        /// Identifies the display language in Hebrew.
        ///
        [EnumMember(Value = "iw")]
        Hebrew = 20,

        ///
        /// Identifies the display language in Hindi.
        ///
        [EnumMember(Value = "hi")]
        Hindi = 21,

        ///
        /// Identifies the display language in Hungarain.
        ///
        [EnumMember(Value = "hu")]
        Hungarain = 22,

        ///
        /// Identifies the display language in Indonesian.
        ///
        [EnumMember(Value = "id")]
        Indonesian = 23,

        ///
        /// Identifies the display language in Italian.
        ///
        [EnumMember(Value = "it")]
        Italian = 24,

        ///
        /// Identifies the display language in Japanese.
        ///
        [EnumMember(Value = "ja")]
        Japanese = 25,

        ///
        /// Identifies the display language in Korean.
        ///
        [EnumMember(Value = "ko")]
        Korean = 26,

        ///
        /// Identifies the display language in Latvian.
        ///
        [EnumMember(Value = "lv")]
        Latvian = 27,

        ///
        /// Identifies the display language in Lithuanian.
        ///
        [EnumMember(Value = "lt")]
        Lithuanian = 28,

        ///
        /// Identifies the display language in Norwegian.
        ///
        [EnumMember(Value = "no")]
        Norwegian = 29,

        ///
        /// Identifies the display language in Persian.
        ///
        [EnumMember(Value = "fa")]
        Persian = 30,

        ///
        /// Identifies the display language in Polish.
        ///
        [EnumMember(Value = "pl")]
        Polish = 31,

        ///
        /// Identifies the display language in Portuguese.
        ///
        [EnumMember(Value = "pt")]
        Portuguese = 32,

        ///
        /// Identifies the display language in Portuguese (Brazil).
        ///
        [EnumMember(Value = "pt-BR")]
        Portuguese_Brazil = 33,

        ///
        /// Identifies the display language in Portuguese (Portugal).
        ///
        [EnumMember(Value = "pt-PT")]
        Portuguese_Portugal = 34,

        ///
        /// Identifies the display language in Romanian.
        ///
        [EnumMember(Value = "ro")]
        Romanian = 35,

        ///
        /// Identifies the display language in Russian.
        ///
        [EnumMember(Value = "ru")]
        Russian = 36,

        ///
        /// Identifies the display language in Serbian.
        ///
        [EnumMember(Value = "sr")]
        Serbian = 37,

        ///
        /// Identifies the display language in Slovak.
        ///
        [EnumMember(Value = "sk")]
        Slovak = 38,

        ///
        /// Identifies the display language in Slovenian.
        ///
        [EnumMember(Value = "sl")]
        Slovenian = 39,

        ///
        /// Identifies the display language in Spanish.
        ///
        [EnumMember(Value = "es")]
        Spanish = 40,

        ///
        /// Identifies the display language in Spanish (Latin America).
        ///
        [EnumMember(Value = "es-419")]
        Spanish_Latin_America = 41,

        ///
        /// Identifies the display language in Swedish.
        ///
        [EnumMember(Value = "sv")]
        Swedish = 42,

        ///
        /// Identifies the display language in Thai.
        ///
        [EnumMember(Value = "th")]
        Thai = 43,

        ///
        /// Identifies the display language in Turkish.
        ///
        [EnumMember(Value = "tr")]
        Turkish = 44,

        ///
        /// Identifies the display language in Ukrainian.
        ///
        [EnumMember(Value = "uk")]
        Ukrainian = 45,

        ///
        /// Identifies the display language in Vietnamese.
        ///
        [EnumMember(Value = "vi")]
        Vietnamese = 46,
    }
}