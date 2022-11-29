using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiagnosisPrognosis
{

    public class SymptomFilter
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
            foreach (OldIllness x in symptomFilter.handler.getAllIllness().ToArray())
            {
                Console.WriteLine(x.illnessID + " - " + x.illnessName);
                foreach (OldSymptom y in x.getAllSymptom().ToArray())
                {
                    Console.WriteLine("\t" + y.symptomID + " - " + y.symptomName);
                }
            }

            Console.WriteLine("\nAll Symptoms");
            foreach (OldSymptom x in symptomFilter.handler.getAllSymptom().ToArray())
            {
                Console.WriteLine(x.symptomID + " - " + x.symptomName);
            }

            Console.WriteLine("Type symptom id: ");
            symptomFilter.addGivenSymptom();

            Console.WriteLine("\nAll given Symptoms");
            foreach (OldSymptom x in symptomFilter.handler.getAllGivenSymptoms().ToArray())
            {
                Console.WriteLine(x.symptomID + " - " + x.symptomName);
            }

            symptomFilter.handler.checkForMatch();
            symptomFilter.handler.getMatchedIllnesses();

            
            Console.ReadKey();
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
        private List<OldSymptom> symptoms;
        private List<OldIllness> illness;

        private List<OldSymptom> givenSymptoms;
        private List<MatchIllness> matchIllness;

        public Handler()
        {
            symptoms = new List<OldSymptom>();
            illness = new List<OldIllness>();
            tempData();


            givenSymptoms = new List<OldSymptom>();
            matchIllness = new List<MatchIllness>();
        }

        public void tempData()
        {
            symptoms.Clear();
            illness.Clear();

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
            List<OldSymptom> tempSymptom = new List<OldSymptom>();

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
            symptoms.Add(new OldSymptom(symptoms.Count, name));
        }

        public void addIllness(string name, List<OldSymptom> symptoms)
        {
            illness.Add(new OldIllness(illness.Count, name, symptoms));
        }

        public void addIllness(string name, OldSymptom[] symptoms)
        {
            illness.Add(new OldIllness(illness.Count, name, symptoms));
        }

        public void addIllnessSymptom(int illnessID, OldSymptom symptom)
        {
            foreach (OldIllness x in illness.ToArray())
            {
                if (x.illnessID == illnessID)
                {
                    int currentID = x.illnessID;
                    illness[currentID].addSymptom(symptom);
                }
            }
        }

        public OldIllness getIllness(int index)
        {
            return illness[index];
        }

        public List<OldIllness> getAllIllness()
        {
            return illness;
        }

        public OldSymptom getSymptom(int index)
        {
            return symptoms[index];
        }

        public List<OldSymptom> getAllSymptom()
        {
            return symptoms;
        }



        public void addGivenSymptom(OldSymptom symptom)
        {
            givenSymptoms.Add(symptom);
        }

        public void addGivenSymptom(int symptom)
        {
            foreach (OldSymptom x in symptoms.ToArray())
            {
                if (x.symptomID == symptom)
                {
                    givenSymptoms.Add(x);
                }
            }
        }

        public List<OldSymptom> getAllGivenSymptoms()
        {
            return givenSymptoms;
        }

        public void checkForMatch()
        {
            foreach (OldSymptom x in givenSymptoms.ToArray())
            {
                //Console.WriteLine("A");
                foreach (OldIllness y in illness.ToArray())
                {
                    //Console.WriteLine("B");
                    foreach (OldSymptom z in y.getAllSymptom())
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
                foreach (OldSymptom y in x.getAllMatches())
                {
                    Console.WriteLine("\t" + y.symptomID + " - " + y.symptomName);
                }
            }
            Console.WriteLine("");
        }
        public List<Illness> getMatchedIllnessesX()
        {
            List<Illness> matches = new List<Illness>();
            //Console.WriteLine("Matched illnesses:");
            foreach (MatchIllness x in matchIllness)
            {
                matches.Add(new Illness(x));
            }

            //Console.WriteLine("");
            return matches;
        }
    }
    
    public class OldIllness
    {
        private int _illnessID;
        private string _illnessName;
        private List<OldSymptom> _symptoms;

        public int illnessID { get => _illnessID; set => _illnessID = value; }
        public string illnessName { get => _illnessName; set => _illnessName = value; }

        public OldIllness(int illnessID, string illnessName, List<OldSymptom> matchedSymptoms)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<OldSymptom>(matchedSymptoms);
        }

        public OldIllness(int illnessID, string illnessName, OldSymptom[] matchedSymptoms)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<OldSymptom>(matchedSymptoms);
        }

        public List<OldSymptom> returnSymptoms()
        {
            return _symptoms;
        }

        public OldSymptom getSymptom(int index)
        {
            return _symptoms[index];
        }

        public List<OldSymptom> getAllSymptom()
        {
            return _symptoms;
        }

        public void addSymptom(OldSymptom symptom)
        {
            _symptoms.Add(symptom);
        }

        public int getNumOfSymptoms()
        {
            return _symptoms.Count;
        }
    }

    public class MatchIllness : OldIllness
    {
        private List<OldSymptom> MatchSymptoms;
        public MatchIllness(int illnessID, string illnessName, List<OldSymptom> matchedSymptoms)
            : base(illnessID, illnessName, matchedSymptoms)
        {
            MatchSymptoms = new List<OldSymptom>();
        }
        public MatchIllness(int illnessID, string illnessName, List<OldSymptom> matchedSymptoms, OldSymptom newSymptom)
            : base(illnessID, illnessName, matchedSymptoms)
        {
            MatchSymptoms = new List<OldSymptom>();
            MatchSymptoms.Add(newSymptom);
        }

        public void AddSymptoms(OldSymptom symptom)
        {
            MatchSymptoms.Add(symptom);
        }

        public void AddSymptoms(OldSymptom[] symptoms)
        {
            MatchSymptoms.AddRange(symptoms);
        }

        public List<OldSymptom> getAllMatches()
        {
            return MatchSymptoms;
        }

        public int getNumOfMatches()
        {
            return MatchSymptoms.Count;
        }
    }

    public class OldSymptom
    {
        private int _symptomID;
        private string _symptomName;

        public int symptomID { get => _symptomID; set => _symptomID = value; }
        public string symptomName { get => _symptomName; set => _symptomName = value; }

        public OldSymptom(int symptomID, string symptomName)
        {
            _symptomID = symptomID;
            _symptomName = symptomName;
        }
    }
    
}
