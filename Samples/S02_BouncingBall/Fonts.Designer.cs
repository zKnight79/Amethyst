﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S02_BouncingBall {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Fonts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Fonts() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("S02_BouncingBall.Fonts", typeof(Fonts).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à COMIC_OUTLINE_72.
        /// </summary>
        internal static string COMIC72_FONT_NAME {
            get {
                return ResourceManager.GetString("COMIC72_FONT_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à &lt;?xml version=&quot;1.0&quot;?&gt;
        ///&lt;font&gt;
        ///  &lt;info face=&quot;Comic Sans MS&quot; size=&quot;72&quot; bold=&quot;0&quot; italic=&quot;0&quot; charset=&quot;&quot; unicode=&quot;1&quot; stretchH=&quot;100&quot; smooth=&quot;1&quot; aa=&quot;2&quot; padding=&quot;0,0,0,0&quot; spacing=&quot;1,1&quot; outline=&quot;3&quot;/&gt;
        ///  &lt;common lineHeight=&quot;72&quot; base=&quot;57&quot; scaleW=&quot;1024&quot; scaleH=&quot;512&quot; pages=&quot;1&quot; packed=&quot;0&quot; alphaChnl=&quot;1&quot; redChnl=&quot;0&quot; greenChnl=&quot;0&quot; blueChnl=&quot;0&quot;/&gt;
        ///  &lt;pages&gt;
        ///    &lt;page id=&quot;0&quot; file=&quot;ComicSansMS_Outline_72.png&quot; /&gt;
        ///  &lt;/pages&gt;
        ///  &lt;chars count=&quot;191&quot;&gt;
        ///    &lt;char id=&quot;32&quot; x=&quot;1016&quot; y=&quot;51&quot; width=&quot;7&quot; height=&quot;7&quot; xoffset=&quot;-3&quot; yoffset=&quot;- [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string ComicSansMS_Outline_72 {
            get {
                return ResourceManager.GetString("ComicSansMS_Outline_72", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ComicSansMS_Outline_72_TEX {
            get {
                object obj = ResourceManager.GetObject("ComicSansMS_Outline_72_TEX", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
