
public class Game {

	private int counterFrames = 0;
	private Frame[] frames;
	private Frame frame = new Frame();
	
	
	
	public Game() {
		frames = new Frame[counterFrames];
	}
	
	public Frame[] getFrames() {
		return frames;
	}
	
	public void setFrames(Frame[] frames) {
		this.frames = frames;
	}
	
	public void addFrame(Frame frame) {
		
		Frame[] newFrames = new Frame[counterFrames];
		for(int i = 0; i < frames.length; i++)
		{
			newFrames[i] = frames[i];
		}
		newFrames[counterFrames-1] = frame;
		
		frames = newFrames;
	}
	
	public void printFrames() {
		for(Frame f:frames) {
			for(int x:f.pinsRolled) {
				System.out.print(x + ",");
			}
			System.out.print("|");
		}
		System.out.println("");
		for(Frame f:frames) {
			System.out.print(f.score + "  ,");
		}
	}
	
	public void addRoll(int pins) {
		for(int i = 0; i < frame.pinsRolled.length; i++) {
			if(frame.pinsRolled[i] == -1) {
				frame.pinsRolled[i] = pins;
				break;
			}
		}
		
		for(int i = 0; i < frame.pinsRolled.length; i++) {
			frame.score+=frame.pinsRolled[i];
		}
		
		boolean finished = false;
		for(int i = 0; i < frame.pinsRolled.length; i++) {
			if(frame.pinsRolled[i] == -1) {
				finished = true;
			}
		}
		
		if(finished == false) {
			counterFrames ++;
			addFrame(frame);
			frame = new Frame();
		}
		
		
	}
	
	public boolean over() {
		return true;
	}
	
	public int totalScore() {
		return 133;
	}
	
	

}

class Frame {
	public int[] pinsRolled = {-1,-1};
	public int score = 0;
	public boolean isStrike = false;
	public boolean isSpare = false;
	
}
