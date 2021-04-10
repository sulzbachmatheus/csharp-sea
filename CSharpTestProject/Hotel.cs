using System.Collections.Generic;

public abstract class Hotel {
    public string Tipo { get; set; }    
    public abstract int TotalTaxa { get; set; }
    public abstract int Classificacao { get; }
    public string[] DiasSemana = {"mon", "tues", "wed", "thur", "fri"};
    public string[] DiasFinalSemana = {"sat", "sun"};
    public Hotel(string tipoHotel){
        this.Tipo = tipoHotel;
    }
    public abstract int GetTaxa(List<string> dias, string tipoParticipante);
}