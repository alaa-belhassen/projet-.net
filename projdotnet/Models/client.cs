//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projdotnet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            this.commande = new HashSet<commande>();
            this.panier = new HashSet<panier>();
        }
    
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public Nullable<int> tel { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public Nullable<double> money { get; set; }
        public string role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commande> commande { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<panier> panier { get; set; }
    }
}
