using System;

namespace _12OOPDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Notepad notepad = new Notepad(null);
            // Notepad notepad = new Notepad("fr");
            //Notepad notepad = new Notepad("hindi");
            //HindiSpellChecker hindiObj = new HindiSpellChecker();
            //Notepad notepad1 = new Notepad(hindiObj);
            //-----------------------------------------------------
            Notepad notepad1 = new Notepad(null);
            //-----------------------------------------------------
            //SpellCheckerFactory spellCheckerFactory = new SpellCheckerFactory();
            // ISpellChecker checker =  spellCheckerFactory.GetSpellChecker("gr");
            //Notepad notepad1 = new Notepad(checker);

            notepad1.SpellCheck();
        }
    }
    #region First approach based on lang selection 
    //public class Notepad
    //{
    //    //Notepad has Cut, Copy , Paste like functionalities here ....
    //    private ISpellChecker _someSpellChecker = null;
    //    SpellCheckerFactory factory = new SpellCheckerFactory();
    //    public Notepad(string lang)
    //    {
    //        if(lang == null) 
    //        {
    //            _someSpellChecker = factory.GetSpellChecker("eng");
    //        }else
    //        {
    //            _someSpellChecker = factory.GetSpellChecker(lang);
    //        }
    //    }
    //    public void SpellCheck()
    //    {
    //        _someSpellChecker.DoSpellCheck();
    //    }
    //} 
    #endregion
    public class Notepad
    {
        //Notepad has Cut, Copy , Paste like functionalities here ....
        private ISpellChecker _someSpellChecker = null;
        SpellCheckerFactory factory = new SpellCheckerFactory();
        public Notepad(ISpellChecker checker)//Constructor Dependency Injection
        {
            if (checker == null)
            {
                _someSpellChecker = factory.GetSpellChecker("fr");
            }
            else
            {
                _someSpellChecker = checker;
            }
        }
        public void SpellCheck()
        {
            _someSpellChecker.DoSpellCheck();
        }
    }
    public class HindiSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for Hindi!");
        }
    }
    public interface ISpellChecker
    {
        void DoSpellCheck();
    }
    public class SpellCheckerFactory
    {
        public ISpellChecker GetSpellChecker(string lang)
        {
            ISpellChecker spellChecker = null;
            switch (lang)
            {
                case "eng":
                    spellChecker = new EnglishSpellChecker();
                    break;
                case "gr":
                    spellChecker = new GermanSpellChecker();
                    break;
                case "fr":
                    spellChecker = new FrenchSpellChecker();
                    break;
                default:
                    spellChecker = new EnglishSpellChecker();
                    break;
            }
            return spellChecker;
        }
    }
    public class EnglishSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for English!");
        }
    }
    public class GermanSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for German!");
        }
    }
    public class FrenchSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            //500 lines code here to do the spell checking.. 
            Console.WriteLine("Spell Check done for French!");
        }
    }
}

