using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibFIKSIO
{
    // bær genereres fra XSD ikke via kode paste
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2", IsNullable = false)]
    public partial class Byggesak
    {

        private object systemIdField;

        private string tittelField;

        private ByggesakSaksnummer saksnummerField;

        private ByggesakKategori kategoriField;

        private ByggesakTiltakstype tiltakstypeField;

        private ByggesakVedtak vedtakField;

        private ByggesakAnsvarligSoeker ansvarligSoekerField;

        private ByggesakTiltakshaver tiltakshaverField;

        private ByggesakMatrikkelopplysninger matrikkelopplysningerField;

        private string adresseField;

        private object referanseAndreSakerField;

        private object referanseKlagesakerField;

        private System.DateTime registrertDatoField;

        private string saksbehandlerField;

        private object posisjonField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object systemId
        {
            get
            {
                return this.systemIdField;
            }
            set
            {
                this.systemIdField = value;
            }
        }

        /// <remarks/>
        public string tittel
        {
            get
            {
                return this.tittelField;
            }
            set
            {
                this.tittelField = value;
            }
        }

        /// <remarks/>
        public ByggesakSaksnummer saksnummer
        {
            get
            {
                return this.saksnummerField;
            }
            set
            {
                this.saksnummerField = value;
            }
        }

        /// <remarks/>
        public ByggesakKategori kategori
        {
            get
            {
                return this.kategoriField;
            }
            set
            {
                this.kategoriField = value;
            }
        }

        /// <remarks/>
        public ByggesakTiltakstype tiltakstype
        {
            get
            {
                return this.tiltakstypeField;
            }
            set
            {
                this.tiltakstypeField = value;
            }
        }

        /// <remarks/>
        public ByggesakVedtak vedtak
        {
            get
            {
                return this.vedtakField;
            }
            set
            {
                this.vedtakField = value;
            }
        }

        /// <remarks/>
        public ByggesakAnsvarligSoeker ansvarligSoeker
        {
            get
            {
                return this.ansvarligSoekerField;
            }
            set
            {
                this.ansvarligSoekerField = value;
            }
        }

        /// <remarks/>
        public ByggesakTiltakshaver tiltakshaver
        {
            get
            {
                return this.tiltakshaverField;
            }
            set
            {
                this.tiltakshaverField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysninger matrikkelopplysninger
        {
            get
            {
                return this.matrikkelopplysningerField;
            }
            set
            {
                this.matrikkelopplysningerField = value;
            }
        }

        /// <remarks/>
        public string adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object referanseAndreSaker
        {
            get
            {
                return this.referanseAndreSakerField;
            }
            set
            {
                this.referanseAndreSakerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object referanseKlagesaker
        {
            get
            {
                return this.referanseKlagesakerField;
            }
            set
            {
                this.referanseKlagesakerField = value;
            }
        }

        /// <remarks/>
        public System.DateTime registrertDato
        {
            get
            {
                return this.registrertDatoField;
            }
            set
            {
                this.registrertDatoField = value;
            }
        }

        /// <remarks/>
        public string saksbehandler
        {
            get
            {
                return this.saksbehandlerField;
            }
            set
            {
                this.saksbehandlerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object posisjon
        {
            get
            {
                return this.posisjonField;
            }
            set
            {
                this.posisjonField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakSaksnummer
    {

        private ushort saksaarField;

        private uint sakssekvensnummerField;

        /// <remarks/>
        public ushort saksaar
        {
            get
            {
                return this.saksaarField;
            }
            set
            {
                this.saksaarField = value;
            }
        }

        /// <remarks/>
        public uint sakssekvensnummer
        {
            get
            {
                return this.sakssekvensnummerField;
            }
            set
            {
                this.sakssekvensnummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakKategori
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakTiltakstype
    {

        private ByggesakTiltakstypeTiltaktype tiltaktypeField;

        /// <remarks/>
        public ByggesakTiltakstypeTiltaktype tiltaktype
        {
            get
            {
                return this.tiltaktypeField;
            }
            set
            {
                this.tiltaktypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakTiltakstypeTiltaktype
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakVedtak
    {

        private string beskrivelseField;

        private System.DateTime vedtaksdatoField;

        private ByggesakVedtakStatus statusField;

        private object dispensasjonerField;

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }

        /// <remarks/>
        public System.DateTime vedtaksdato
        {
            get
            {
                return this.vedtaksdatoField;
            }
            set
            {
                this.vedtaksdatoField = value;
            }
        }

        /// <remarks/>
        public ByggesakVedtakStatus status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object dispensasjoner
        {
            get
            {
                return this.dispensasjonerField;
            }
            set
            {
                this.dispensasjonerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakVedtakStatus
    {

        private byte kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public byte kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakAnsvarligSoeker
    {

        private object foedselsnummerField;

        private uint organisasjonsnummerField;

        private string navnField;

        private object adresseField;

        private object telefonnummerField;

        private object mobilnummerField;

        private object epostField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object foedselsnummer
        {
            get
            {
                return this.foedselsnummerField;
            }
            set
            {
                this.foedselsnummerField = value;
            }
        }

        /// <remarks/>
        public uint organisasjonsnummer
        {
            get
            {
                return this.organisasjonsnummerField;
            }
            set
            {
                this.organisasjonsnummerField = value;
            }
        }

        /// <remarks/>
        public string navn
        {
            get
            {
                return this.navnField;
            }
            set
            {
                this.navnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object telefonnummer
        {
            get
            {
                return this.telefonnummerField;
            }
            set
            {
                this.telefonnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object mobilnummer
        {
            get
            {
                return this.mobilnummerField;
            }
            set
            {
                this.mobilnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object epost
        {
            get
            {
                return this.epostField;
            }
            set
            {
                this.epostField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakTiltakshaver
    {

        private ulong foedselsnummerField;

        private object organisasjonsnummerField;

        private string navnField;

        private object adresseField;

        private object telefonnummerField;

        private object mobilnummerField;

        private object epostField;

        /// <remarks/>
        public ulong foedselsnummer
        {
            get
            {
                return this.foedselsnummerField;
            }
            set
            {
                this.foedselsnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object organisasjonsnummer
        {
            get
            {
                return this.organisasjonsnummerField;
            }
            set
            {
                this.organisasjonsnummerField = value;
            }
        }

        /// <remarks/>
        public string navn
        {
            get
            {
                return this.navnField;
            }
            set
            {
                this.navnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object telefonnummer
        {
            get
            {
                return this.telefonnummerField;
            }
            set
            {
                this.telefonnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object mobilnummer
        {
            get
            {
                return this.mobilnummerField;
            }
            set
            {
                this.mobilnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object epost
        {
            get
            {
                return this.epostField;
            }
            set
            {
                this.epostField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysninger
    {

        private ByggesakMatrikkelopplysningerEiendomsidentifikasjon eiendomsidentifikasjonField;

        private ByggesakMatrikkelopplysningerAdresse[] adresseField;

        private ByggesakMatrikkelopplysningerBygning[] bygningField;

        /// <remarks/>
        public ByggesakMatrikkelopplysningerEiendomsidentifikasjon eiendomsidentifikasjon
        {
            get
            {
                return this.eiendomsidentifikasjonField;
            }
            set
            {
                this.eiendomsidentifikasjonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("adresse", IsNullable = false)]
        public ByggesakMatrikkelopplysningerAdresse[] adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("bygning", IsNullable = false)]
        public ByggesakMatrikkelopplysningerBygning[] bygning
        {
            get
            {
                return this.bygningField;
            }
            set
            {
                this.bygningField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerEiendomsidentifikasjon
    {

        private ByggesakMatrikkelopplysningerEiendomsidentifikasjonMatrikkelnummer matrikkelnummerField;

        /// <remarks/>
        public ByggesakMatrikkelopplysningerEiendomsidentifikasjonMatrikkelnummer matrikkelnummer
        {
            get
            {
                return this.matrikkelnummerField;
            }
            set
            {
                this.matrikkelnummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerEiendomsidentifikasjonMatrikkelnummer
    {

        private ushort kommunenummerField;

        private ushort gaardsnummerField;

        private byte bruksnummerField;

        private object festenummerField;

        private object seksjonsnummerField;

        /// <remarks/>
        public ushort kommunenummer
        {
            get
            {
                return this.kommunenummerField;
            }
            set
            {
                this.kommunenummerField = value;
            }
        }

        /// <remarks/>
        public ushort gaardsnummer
        {
            get
            {
                return this.gaardsnummerField;
            }
            set
            {
                this.gaardsnummerField = value;
            }
        }

        /// <remarks/>
        public byte bruksnummer
        {
            get
            {
                return this.bruksnummerField;
            }
            set
            {
                this.bruksnummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object festenummer
        {
            get
            {
                return this.festenummerField;
            }
            set
            {
                this.festenummerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object seksjonsnummer
        {
            get
            {
                return this.seksjonsnummerField;
            }
            set
            {
                this.seksjonsnummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerAdresse
    {

        private ushort adressekodeField;

        private string adressenavnField;

        private byte adressenummerField;

        private string adressebokstavField;

        private object seksjonsnummerField;

        /// <remarks/>
        public ushort adressekode
        {
            get
            {
                return this.adressekodeField;
            }
            set
            {
                this.adressekodeField = value;
            }
        }

        /// <remarks/>
        public string adressenavn
        {
            get
            {
                return this.adressenavnField;
            }
            set
            {
                this.adressenavnField = value;
            }
        }

        /// <remarks/>
        public byte adressenummer
        {
            get
            {
                return this.adressenummerField;
            }
            set
            {
                this.adressenummerField = value;
            }
        }

        /// <remarks/>
        public string adressebokstav
        {
            get
            {
                return this.adressebokstavField;
            }
            set
            {
                this.adressebokstavField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object seksjonsnummer
        {
            get
            {
                return this.seksjonsnummerField;
            }
            set
            {
                this.seksjonsnummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygning
    {

        private object bygningsnummerField;

        private ByggesakMatrikkelopplysningerBygningNaeringsgruppe naeringsgruppeField;

        private ByggesakMatrikkelopplysningerBygningBygningstype bygningstypeField;

        private byte bebygdArealField;

        private ByggesakMatrikkelopplysningerBygningBruksenhet[] bruksenheterField;

        private ByggesakMatrikkelopplysningerBygningEtasjer etasjerField;

        private ByggesakMatrikkelopplysningerBygningAvlop avlopField;

        private object energiforsyningField;

        private ByggesakMatrikkelopplysningerBygningVannforsyning vannforsyningField;

        private bool harHeisField;

        private string endringField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object bygningsnummer
        {
            get
            {
                return this.bygningsnummerField;
            }
            set
            {
                this.bygningsnummerField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningNaeringsgruppe naeringsgruppe
        {
            get
            {
                return this.naeringsgruppeField;
            }
            set
            {
                this.naeringsgruppeField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBygningstype bygningstype
        {
            get
            {
                return this.bygningstypeField;
            }
            set
            {
                this.bygningstypeField = value;
            }
        }

        /// <remarks/>
        public byte bebygdAreal
        {
            get
            {
                return this.bebygdArealField;
            }
            set
            {
                this.bebygdArealField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("bruksenhet", IsNullable = false)]
        public ByggesakMatrikkelopplysningerBygningBruksenhet[] bruksenheter
        {
            get
            {
                return this.bruksenheterField;
            }
            set
            {
                this.bruksenheterField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningEtasjer etasjer
        {
            get
            {
                return this.etasjerField;
            }
            set
            {
                this.etasjerField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningAvlop avlop
        {
            get
            {
                return this.avlopField;
            }
            set
            {
                this.avlopField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object energiforsyning
        {
            get
            {
                return this.energiforsyningField;
            }
            set
            {
                this.energiforsyningField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningVannforsyning vannforsyning
        {
            get
            {
                return this.vannforsyningField;
            }
            set
            {
                this.vannforsyningField = value;
            }
        }

        /// <remarks/>
        public bool harHeis
        {
            get
            {
                return this.harHeisField;
            }
            set
            {
                this.harHeisField = value;
            }
        }

        /// <remarks/>
        public string endring
        {
            get
            {
                return this.endringField;
            }
            set
            {
                this.endringField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningNaeringsgruppe
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBygningstype
    {

        private byte kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public byte kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhet
    {

        private ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummer bruksenhetsnummerField;

        private ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetstype bruksenhetstypeField;

        private byte bruksarealField;

        private ByggesakMatrikkelopplysningerBygningBruksenhetKjoekkentilgang kjoekkentilgangField;

        private byte antallRomField;

        private byte antallBadField;

        private byte antallWCField;

        private ByggesakMatrikkelopplysningerBygningBruksenhetAdresse adresseField;

        private object matrikkelnummerField;

        private string endringField;

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummer bruksenhetsnummer
        {
            get
            {
                return this.bruksenhetsnummerField;
            }
            set
            {
                this.bruksenhetsnummerField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetstype bruksenhetstype
        {
            get
            {
                return this.bruksenhetstypeField;
            }
            set
            {
                this.bruksenhetstypeField = value;
            }
        }

        /// <remarks/>
        public byte bruksareal
        {
            get
            {
                return this.bruksarealField;
            }
            set
            {
                this.bruksarealField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBruksenhetKjoekkentilgang kjoekkentilgang
        {
            get
            {
                return this.kjoekkentilgangField;
            }
            set
            {
                this.kjoekkentilgangField = value;
            }
        }

        /// <remarks/>
        public byte antallRom
        {
            get
            {
                return this.antallRomField;
            }
            set
            {
                this.antallRomField = value;
            }
        }

        /// <remarks/>
        public byte antallBad
        {
            get
            {
                return this.antallBadField;
            }
            set
            {
                this.antallBadField = value;
            }
        }

        /// <remarks/>
        public byte antallWC
        {
            get
            {
                return this.antallWCField;
            }
            set
            {
                this.antallWCField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBruksenhetAdresse adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object matrikkelnummer
        {
            get
            {
                return this.matrikkelnummerField;
            }
            set
            {
                this.matrikkelnummerField = value;
            }
        }

        /// <remarks/>
        public string endring
        {
            get
            {
                return this.endringField;
            }
            set
            {
                this.endringField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummer
    {

        private ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummerEtasjeplan etasjeplanField;

        private byte etasjenummerField;

        private byte loepenummerField;

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummerEtasjeplan etasjeplan
        {
            get
            {
                return this.etasjeplanField;
            }
            set
            {
                this.etasjeplanField = value;
            }
        }

        /// <remarks/>
        public byte etasjenummer
        {
            get
            {
                return this.etasjenummerField;
            }
            set
            {
                this.etasjenummerField = value;
            }
        }

        /// <remarks/>
        public byte loepenummer
        {
            get
            {
                return this.loepenummerField;
            }
            set
            {
                this.loepenummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetsnummerEtasjeplan
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhetBruksenhetstype
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhetKjoekkentilgang
    {

        private byte kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public byte kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningBruksenhetAdresse
    {

        private ushort adressekodeField;

        private string adressenavnField;

        private byte adressenummerField;

        private string adressebokstavField;

        private object seksjonsnummerField;

        /// <remarks/>
        public ushort adressekode
        {
            get
            {
                return this.adressekodeField;
            }
            set
            {
                this.adressekodeField = value;
            }
        }

        /// <remarks/>
        public string adressenavn
        {
            get
            {
                return this.adressenavnField;
            }
            set
            {
                this.adressenavnField = value;
            }
        }

        /// <remarks/>
        public byte adressenummer
        {
            get
            {
                return this.adressenummerField;
            }
            set
            {
                this.adressenummerField = value;
            }
        }

        /// <remarks/>
        public string adressebokstav
        {
            get
            {
                return this.adressebokstavField;
            }
            set
            {
                this.adressebokstavField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object seksjonsnummer
        {
            get
            {
                return this.seksjonsnummerField;
            }
            set
            {
                this.seksjonsnummerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningEtasjer
    {

        private ByggesakMatrikkelopplysningerBygningEtasjerEtasje etasjeField;

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningEtasjerEtasje etasje
        {
            get
            {
                return this.etasjeField;
            }
            set
            {
                this.etasjeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningEtasjerEtasje
    {

        private byte etasjenummerField;

        private ByggesakMatrikkelopplysningerBygningEtasjerEtasjeEtasjeplan etasjeplanField;

        private byte antallBoenheterField;

        private byte bruksarealTilAnnetField;

        private byte bruksarealTilBoligField;

        private byte bruksarealTotaltField;

        private string endringField;

        /// <remarks/>
        public byte etasjenummer
        {
            get
            {
                return this.etasjenummerField;
            }
            set
            {
                this.etasjenummerField = value;
            }
        }

        /// <remarks/>
        public ByggesakMatrikkelopplysningerBygningEtasjerEtasjeEtasjeplan etasjeplan
        {
            get
            {
                return this.etasjeplanField;
            }
            set
            {
                this.etasjeplanField = value;
            }
        }

        /// <remarks/>
        public byte antallBoenheter
        {
            get
            {
                return this.antallBoenheterField;
            }
            set
            {
                this.antallBoenheterField = value;
            }
        }

        /// <remarks/>
        public byte bruksarealTilAnnet
        {
            get
            {
                return this.bruksarealTilAnnetField;
            }
            set
            {
                this.bruksarealTilAnnetField = value;
            }
        }

        /// <remarks/>
        public byte bruksarealTilBolig
        {
            get
            {
                return this.bruksarealTilBoligField;
            }
            set
            {
                this.bruksarealTilBoligField = value;
            }
        }

        /// <remarks/>
        public byte bruksarealTotalt
        {
            get
            {
                return this.bruksarealTotaltField;
            }
            set
            {
                this.bruksarealTotaltField = value;
            }
        }

        /// <remarks/>
        public string endring
        {
            get
            {
                return this.endringField;
            }
            set
            {
                this.endringField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningEtasjerEtasjeEtasjeplan
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningAvlop
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://rep.geointegrasjon.no/Matrikkel/foering/v2")]
    public partial class ByggesakMatrikkelopplysningerBygningVannforsyning
    {

        private string kodeField;

        private string beskrivelseField;

        /// <remarks/>
        public string kode
        {
            get
            {
                return this.kodeField;
            }
            set
            {
                this.kodeField = value;
            }
        }

        /// <remarks/>
        public string beskrivelse
        {
            get
            {
                return this.beskrivelseField;
            }
            set
            {
                this.beskrivelseField = value;
            }
        }
    }


}
