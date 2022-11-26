using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiagnosisPrognosis
{

    internal class SymptomFilter
    {
        Handler handler;
        public SymptomFilter()
        {
            handler = new Handler();
        }
        //not gonna touch this much, just made sure theres no conflicts with the rest of the program
        //just fix whatever you need afterwards tyvm
        static void symptomFilterMain(string[] args)
        {
            SymptomFilter symptomFilter = new SymptomFilter();
            Console.WriteLine("\nAll illnesses");
            foreach (Illness x in symptomFilter.handler.getAllIllness().ToArray())
            {
                Console.WriteLine(x.illnessID + " - " + x.illnessName);
                foreach (Symptom y in x.getAllSymptom().ToArray())
                {
                    Console.WriteLine("\t" + y.symptomID + " - " + y.symptomName);
                }
            }

            Console.WriteLine("\nAll Symptoms");
            foreach (Symptom x in symptomFilter.handler.getAllSymptom().ToArray())
            {
                Console.WriteLine(x.symptomID + " - " + x.symptomName);
            }

            Console.WriteLine("Type symptom id: ");
            symptomFilter.addGivenSymptom();

            Console.WriteLine("\nAll given Symptoms");
            foreach (Symptom x in symptomFilter.handler.getAllGivenSymptoms().ToArray())
            {
                Console.WriteLine(x.symptomID + " - " + x.symptomName);
            }

            symptomFilter.handler.checkForMatch();
            symptomFilter.handler.getMatchedIllnesses();

            /* END */
            Console.ReadKey(); /* END */
        }

        Regex rx = new Regex(@"([0-9])");

        public void addGivenSymptom()
        {
            int ID = Convert.ToInt32(Console.ReadLine());
            handler.addGivenSymptom(ID);
            Console.WriteLine("Enter another ID to add another, Enter any non-numeric to exit");
            String input = Console.ReadLine();
            if (rx.IsMatch(input))
            {
                addGivenSymptom(Convert.ToInt32(input));
            }
        }
        public void addGivenSymptom(int newID)
        {
            handler.addGivenSymptom(newID);

            Console.WriteLine("Enter another ID to add another, Enter any non-numeric to exit");
            String input = Console.ReadLine();
            if (rx.IsMatch(input))
            {
                addGivenSymptom(Convert.ToInt32(input));
            }
        }
    }

    public class Handler
    {
        private List<Symptom> symptoms;
        private List<Illness> illness;

        private List<Symptom> givenSymptoms;
        private List<MatchIllness> matchIllness;

        public Handler()
        {
            symptoms = new List<Symptom>();
            illness = new List<Illness>();
            tempData();


            givenSymptoms = new List<Symptom>();
            matchIllness = new List<MatchIllness>();
        }

        public void tempData()
        {
            addSymptoms("Cough"); // 0
            addSymptoms("Fever"); // 1
            addSymptoms("Runny Nose"); // 2
            addSymptoms("Stuffy Nose"); // 3
            addSymptoms("Sore Throat"); // 4
            addSymptoms("Tiredness"); // 5
            addSymptoms("Loss of taste or smell"); // 6
            addSymptoms("Aches"); // 7
            addSymptoms("Diarrhoea"); // 8
            addSymptoms("Rashes"); // 9
            addSymptoms("Irritated eyes"); // 10
            addSymptoms("Shortness of breath"); // 11
            addSymptoms("Confusion"); // 12
            addSymptoms("Chest pain"); // 13
            addSymptoms("Vomitting"); // 14
            addSymptoms("Headache"); // 15
            addSymptoms("Sneezing"); // 16
            addSymptoms("Post-nasal drip"); // 17
            addSymptoms("Watery eyes"); // 18
            List<Symptom> tempSymptom = new List<Symptom>();

            tempSymptom.Add(symptoms[0]);
            tempSymptom.Add(symptoms[1]);
            tempSymptom.Add(symptoms[2]);
            tempSymptom.Add(symptoms[3]);
            tempSymptom.Add(symptoms[4]);
            tempSymptom.Add(symptoms[16]);
            tempSymptom.Add(symptoms[17]);
            tempSymptom.Add(symptoms[18]);
            addIllness("Cold", tempSymptom);

            tempSymptom.Clear();
            tempSymptom.Add(symptoms[0]);
            tempSymptom.Add(symptoms[1]);
            tempSymptom.Add(symptoms[2]);
            tempSymptom.Add(symptoms[3]);
            tempSymptom.Add(symptoms[4]);
            tempSymptom.Add(symptoms[5]);
            tempSymptom.Add(symptoms[8]);
            tempSymptom.Add(symptoms[14]);
            tempSymptom.Add(symptoms[15]);
            addIllness("Flu", tempSymptom);

            tempSymptom.Clear();
            tempSymptom.Add(symptoms[0]);
            tempSymptom.Add(symptoms[1]);
            tempSymptom.Add(symptoms[5]);
            tempSymptom.Add(symptoms[6]);
            tempSymptom.Add(symptoms[4]);
            tempSymptom.Add(symptoms[7]);
            tempSymptom.Add(symptoms[8]);
            tempSymptom.Add(symptoms[9]);
            tempSymptom.Add(symptoms[10]);
            tempSymptom.Add(symptoms[11]);
            tempSymptom.Add(symptoms[12]);
            tempSymptom.Add(symptoms[13]);
            tempSymptom.Add(symptoms[15]);
            addIllness("COVID-19", tempSymptom);
        }


        public void addSymptoms(string name)
        {
            symptoms.Add(new Symptom(symptoms.Count, name));
        }

        public void addIllness(string name, List<Symptom> symptoms)
        {
            illness.Add(new Illness(illness.Count, name, symptoms));
        }

        public void addIllness(string name, Symptom[] symptoms)
        {
            illness.Add(new Illness(illness.Count, name, symptoms));
        }

        public void addIllnessSymptom(int illnessID, Symptom symptom)
        {
            foreach (Illness x in illness.ToArray())
            {
                if (x.illnessID == illnessID)
                {
                    int currentID = x.illnessID;
                    illness[currentID].addSymptom(symptom);
                }
            }
        }

        public Illness getIllness(int index)
        {
            return illness[index];
        }

        public List<Illness> getAllIllness()
        {
            return illness;
        }

        public Symptom getSymptom(int index)
        {
            return symptoms[index];
        }

        public List<Symptom> getAllSymptom()
        {
            return symptoms;
        }



        public void addGivenSymptom(Symptom symptom)
        {
            givenSymptoms.Add(symptom);
        }

        public void addGivenSymptom(int symptom)
        {
            foreach (Symptom x in symptoms.ToArray())
            {
                if (x.symptomID == symptom)
                {
                    givenSymptoms.Add(x);
                }
            }
        }

        public List<Symptom> getAllGivenSymptoms()
        {
            return givenSymptoms;
        }

        public void checkForMatch()
        {
            foreach (Symptom x in givenSymptoms.ToArray())
            {
                //Console.WriteLine("A");
                foreach (Illness y in illness.ToArray())
                {
                    //Console.WriteLine("B");
                    foreach (Symptom z in y.getAllSymptom())
                    {
                        //Console.WriteLine("C");
                        if (x.symptomID == z.symptomID)
                        {
                            bool thereIs = false;
                            int index = -1;
                            foreach (MatchIllness a in matchIllness)
                            {
                                //Console.WriteLine("D");
                                if (a.illnessID == y.illnessID)
                                {
                                    thereIs = true;
                                    index = a.illnessID;
                                }
                            }
                            if (!thereIs)
                            {
                                matchIllness.Add(new MatchIllness(y.illnessID, y.illnessName, y.getAllSymptom(), x));
                            }
                            else if (thereIs)
                            {
                                for (int b = 0; b < matchIllness.Count; b++)
                                {
                                    if (matchIllness[b].illnessID == index)
                                    {
                                        matchIllness[b].AddSymptoms(x);
                                    }
                                }
                            }
                        }
                    }
                }

            }
        } // this is checkForMatch() just in case you got lost in the bracket maze

        public void getMatchedIllnesses()
        {

            Console.WriteLine("Matched illnesses:");
            foreach (MatchIllness x in matchIllness)
            {
                Console.WriteLine(x.illnessID + "\t" + x.illnessName + "\t" + x.getNumOfMatches() + "/" + x.getNumOfSymptoms());
                foreach (Symptom y in x.getAllMatches())
                {
                    Console.WriteLine("\t" + y.symptomID + " - " + y.symptomName);
                }
            }
            Console.WriteLine("");
        }
    }

    public class Illness
    {
        private int _illnessID;
        private string _illnessName;
        private List<Symptom> _symptoms;

        public int illnessID { get => _illnessID; set => _illnessID = value; }
        public string illnessName { get => _illnessName; set => _illnessName = value; }

        public Illness(int illnessID, string illnessName, List<Symptom> matchedSymptoms)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<Symptom>(matchedSymptoms);
        }

        public Illness(int illnessID, string illnessName, Symptom[] matchedSymptoms)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<Symptom>(matchedSymptoms);
        }

        public List<Symptom> returnSymptoms()
        {
            return _symptoms;
        }

        public Symptom getSymptom(int index)
        {
            return _symptoms[index];
        }

        public List<Symptom> getAllSymptom()
        {
            return _symptoms;
        }

        public void addSymptom(Symptom symptom)
        {
            _symptoms.Add(symptom);
        }

        public int getNumOfSymptoms()
        {
            return _symptoms.Count;
        }
    }

    public class MatchIllness : Illness
    {
        private List<Symptom> MatchSymptoms;
        public MatchIllness(int illnessID, string illnessName, List<Symptom> matchedSymptoms)
            : base(illnessID, illnessName, matchedSymptoms)
        {
            MatchSymptoms = new List<Symptom>();
        }
        public MatchIllness(int illnessID, string illnessName, List<Symptom> matchedSymptoms, Symptom newSymptom)
            : base(illnessID, illnessName, matchedSymptoms)
        {
            MatchSymptoms = new List<Symptom>();
            MatchSymptoms.Add(newSymptom);
        }

        public void AddSymptoms(Symptom symptom)
        {
            MatchSymptoms.Add(symptom);
        }

        public void AddSymptoms(Symptom[] symptoms)
        {
            MatchSymptoms.AddRange(symptoms);
        }

        public List<Symptom> getAllMatches()
        {
            return MatchSymptoms;
        }

        public int getNumOfMatches()
        {
            return MatchSymptoms.Count;
        }
    }

    public class Symptom
    {
        private int _symptomID;
        private string _symptomName;

        public int symptomID { get => _symptomID; set => _symptomID = value; }
        public string symptomName { get => _symptomName; set => _symptomName = value; }

        public Symptom(int symptomID, string symptomName)
        {
            _symptomID = symptomID;
            _symptomName = symptomName;
        }
    }
}
