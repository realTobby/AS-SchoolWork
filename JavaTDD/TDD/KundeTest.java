import org.junit.*;                      // JUNIT 4: für alle Anotationen
import static org.junit.Assert.*;        // JUNIT 4: für alle assert-Methoden
import org.junit.runner.*;               // JUNIT 4: für JUnitCore und Result
import org.junit.runner.notification.*;  // JUNIT 4: für Failure           

public class KundeTest {
  
  Kunde kunde1;
  
  @Before
  public void initialize() {
    kunde1 = new Kunde();
  }
  
  @Test
  public void getKundenNrTest() {
    assertEquals(0, kunde1.getKundenNr());
  }
  
  @Test
  public void setKundenNrTest() {
    kunde1.setKundenNr(10001);
    assertEquals(10001, kunde1.getKundenNr());
  }
  
  @Test
  public void getKundenNameTest() {
    assertEquals("Unbekannt", kunde1.getKundenName());
  }
  
  @Test
  public void setKundenNameTest() {
    kunde1.setKundenName("Sans");
    assertEquals("Sans", kunde1.getKundenName());
  }
  
  @Test
  public void neuerKundeLeererKonstruktorTest() {
    kunde1 = new Kunde();
    assertEquals("Unbekannt", kunde1.getKundenName());
    assertEquals(0, kunde1.getKundenNr());
  }
  
  @Test
  public void neuerKundeVollerKonstruktorTest() {
    kunde1 = new Kunde("Sans", 10002);
    assertEquals("Sans", kunde1.getKundenName());
    assertEquals(10002, kunde1.getKundenNr());
  }
  
  @Test
  public void toStringTest() {
    String input = "0 Unbekannt";
    assertEquals(input, kunde1.toString());
  }
  
  @Test
  public void equalsTest() {
    assertEquals(true,kunde1.equals(0));
  }
  
  public static void main(String[] args) {
    Result result = JUnitCore.runClasses(KundeTest.class);
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
