import org.junit.*;                      // JUNIT 4: f�r alle Anotationen
import static org.junit.Assert.*;        // JUNIT 4: f�r alle assert-Methoden
import org.junit.runner.*;               // JUNIT 4: f�r JUnitCore und Result
import org.junit.runner.notification.*;  // JUNIT 4: f�r Failure           

public class RechteckTest {
  
  Rechteck rechteck1;
  
  @Before
  public void initialize() {
    rechteck1 = new Rechteck();
  }
    
  @Test
  public void testGetL�nge() {
    assertEquals(0,rechteck1.getL�nge(), 0);
  }
  
  @Test
  public void testSetL�nge() {
    rechteck1.setL�nge(7);
    assertEquals(7,rechteck1.getL�nge(), 0);
  }
  
  @Test
  public void testSetL�ngeMitNegativenWert() {
    rechteck1.setL�nge(-9);
    assertEquals(0,rechteck1.getL�nge(), 0);
  }
  
  @Test
  public void testParametrisierterKonstruktor() {
    Rechteck rechteck2 = new Rechteck(8);
    assertEquals(8,rechteck2.getL�nge(), 0);
  }
  
  @Test
  public void testParametrisierterKonstruktorMitNegativenWerten() {
    Rechteck rechteck2 = new Rechteck(-8);
    assertEquals(0,rechteck2.getL�nge(), 0);
  }
  
  
  public static void main(String[] args) {
    Result result = JUnitCore.runClasses(RechteckTest.class);
    printTUI(result);
  }
  
  public static void printTUI(Result result) {
    System.out.println("Time: " + result.getRunTime() + "ms");
    System.out.println("Number of Tests: " + result.getRunCount());
    System.out.println("Failed: " + result.getFailureCount());
    for (Failure f: result.getFailures()) {
      System.out.println(f.toString());
    } 
  }
  
} 
