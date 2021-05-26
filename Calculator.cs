public class Program
    {
        /*
         * This program takes a file name as argument and an operation (+ or *)
         * it parses the file
         * in this file, each line of the file should hopefully have a valid number
         * it should take each number and print the operation, along with the intermediary result
         * it should print at the end the total result of the defined operation applied to
         * all numbers found in this file (along with the text name of the operation)
         * ex:
         * 1
         * +2 (=3)
         * +3 (=6)
         * -------
         * total = 6 (addition)
         */
        public static void Main(string[] args)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:ffffff")}][log] started");
            string ns = File.ReadAllText(args[0]);
            string o = args[1];
            string on = (o == "+" ? "addition" : (o == "*" ? "multiplication" : "unknown"));
            Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:ffffff")}][log] applying operation {on}");
            Operation operation = new Operation(o);
            Result result = new Result();

            foreach (string s in ns.Split(Environment.NewLine))
            {
                int val = int.Parse(s);
                Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:ffffff")}][log] parsed value = {val}");
                result.displayIntermediateResult(val, operation);

                operation.doOperation(val);

                result.incrementeNumberOfLine();
                Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:ffffff")}][log] accumulation : {t} on line {ln}");
            }
            result.displayFinalResult(operation);
        }
    }

public class Operation
{
    string operationSign {get;set;} 
    int total {get;set;} 

    public Operation(string s){
        this.operationSign = s;
        initializeTotal();
    }

    public int doOperation(int val){
        switch(this.operationSign){
            case "+":
                this.total += val;
                break;
            case "*":
                this.total *= val;
                break;
            default:
                break;
        }
        return total;   
    }

    public initializeTotal(){
        switch(this.operationSign){
            case "+":
                this.total = 0;
                break;
            case "*":
                this.total = 1;
                break;
            default:
                break;
        }
    }
}

public class Result
{
    int numberOfLine;
    
    Result(){
        numberOfLine = 0;
    }

    public void displayIntermediateResult(int val, Operation op){
        if (this.numberOfLine == 0){
            string l = val.ToString();
            Console.WriteLine(l);
        }
        else
        { 
            string l = ( op.getOperationSign() + val.ToString())
                        + " (= " + op.getTotal().ToString() + ")";
            Console.WriteLine(l);     
        }
    }
    public incrementeNumberOfLine(){
        this.numberOfLine +=1;
    }

    public displayFinalResult(Operation op){
        Console.WriteLine("--------------");
        Console.WriteLine("Total = " + t.ToString());
        Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:ffffff")}][log] end of program");
    }
}