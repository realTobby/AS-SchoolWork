org.apache.commons.lang.ArrayUtils


public class Game {

       private int counterFrames;
       private Frame[] frames;
       private Frame frame;
       
       public Game() {
       }
       
       public int getRound() {
              return frames.length; 
       }
       
       public void addRoll(int points) {
              ArrayUtils.add(frame.rolls,points);
       }
       
       public void pushFrame() {
              frames.add(frame);
              frame = new Frame();  
       }
  
}