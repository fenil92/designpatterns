namespace DesignPatterns.SOLID
{
    public class Document
    {

    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d) // Violation: Forced to implement interface which it does not support
        {
            throw new System.NotImplementedException();
        }

        public void Print(Document d)
        {
            // Only printer function works
        }

        public void Scan(Document d) // Violation: Forced to implement interface which it does not support
        {
            throw new System.NotImplementedException();
        }
    }

    public class InterfaceSegregationViolation
    {
    }
}
