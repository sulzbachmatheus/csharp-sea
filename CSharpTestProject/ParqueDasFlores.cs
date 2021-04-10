using System.Collections.Generic;
using System.Linq;

public class ParqueDasFlores : Hotel {
        public override int TotalTaxa { get; set; }
        public override int Classificacao { 
            get { return 3; }
        }
        public ParqueDasFlores (string tipoHotel) : base (tipoHotel) {

         }    
        public override int GetTaxa(List<string> dias, string tipoParticipante) {   
                     
            if (tipoParticipante == "Regular"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 110;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 90;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 80;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 80;
                    }
                }
            }
            return TotalTaxa;
        }
    }