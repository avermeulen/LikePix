public class Counter {

    private int count = 0;

    public void Like(){
        count++;
    }

    public void Unlike() {
        if (count > 0) {
            count--;
        }
    }

    public int Value {
        get{
            return count; 
        }
    }

}