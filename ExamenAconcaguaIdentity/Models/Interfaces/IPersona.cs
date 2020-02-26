namespace ExamenAconcagua.Models.Interfaces
{    
    public interface IPersona: IEntity
    {
        string Dni { get; set; }
        string Nombre { get; set; }
        string PrimerApellido { get; set; }
        string SegundoApellido { get; set; }
        string TelefonoFijo { get; set; }
        string TelefonoMovil { get; set; }              
    }

    public static class IPersonaExtensions 
    { 
        public static string NombreCompleto(this IPersona persona)
        {
            return $"{persona.Nombre} {persona.PrimerApellido} {persona.SegundoApellido}";
        }
    }

}
