using System.Collections.Generic;
using System.Linq;

public class JardimBotanico : Hotel {
        public override int TotalTaxa { get; set; }
        public override int Classificacao { 
            get { return 4; }
        }
        public JardimBotanico (string tipoHotel) : base (tipoHotel) {

        }      
        public override int GetTaxa(List<string> dias, string tipoParticipante) {

            if (tipoParticipante == "Regular"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 160;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 60;
                    }
                }
            } 
            else if (tipoParticipante == "Fidelidade"){
                foreach (var dia in dias){
                    if (DiasSemana.Contains(dia)){
                        TotalTaxa += 110;
                    }
                    else if (DiasFinalSemana.Contains(dia)) {
                        TotalTaxa += 50;
                    }
                }
            }
            return TotalTaxa;
        }
    }
