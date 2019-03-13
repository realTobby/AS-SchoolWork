import junit.framework.TestCase;
import org.junit.Test;

public class GameTest extends TestCase {

	private Game game;
	
	public GameTest() {
		game = new Game();
	}
	
	public int doTheGame(int[] rolls) {
		return game.totalScore();
	}

	@Test
	public void testRegularGame1() {
		int[] rolls = {1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6};
		assertEquals(133, doTheGame(rolls));
	}
	
	@Test
	public void testDoAFrame() {
		game.addRoll(1);
		game.addRoll(4);
		
		game.addRoll(4);
		game.addRoll(5);
		
		game.addRoll(6);
		game.addRoll(4);
		
		game.addRoll(5);
		game.addRoll(5);
		
		game.addRoll(10);
		game.addRoll(0);
		
		game.addRoll(1);
		game.addRoll(7);
		
		game.addRoll(3);
		game.addRoll(6);
		
		game.addRoll(4);
		game.addRoll(10);
		
		game.addRoll(2);
		game.addRoll(8);
		
		game.addRoll(6);
		game.addRoll(0);
		game.printFrames();
		
	}
	
}
