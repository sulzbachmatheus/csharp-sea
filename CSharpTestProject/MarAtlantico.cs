using System.Collections.Generic;
using System.Linq;

public class MarAtlantico : Hotel {
        public override int TotalTaxa { get; set; }
        public override int Classificacao { 
            get { return 5; } 
        }        
        public MarAtlantico (string tipoHotel) : base (tipoHotel) {
            
         }    
        public override int GetTaxa(List<string> dias, string tipoParticipante) {
            
            if (tipoParticipante == "Regular"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 220;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 150;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 100;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 40;
                    }
                }
            }
            return TotalTaxa;
        }
    }