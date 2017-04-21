/*
 * Created by Stephen White on 4/19/2017.
 *
 * This suite of automated unit tests cover what it is like to model
 * basic attributes of the Microsoft Hololens and are intended to
 * assist in the understanding of how our project works .
 */

// Include all necessary import statements
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.assertEquals;

// CLASS DECLARATION
public class AutomatedTests {

    // Set up the unit tests
    @Before
    public void setUp() throws Exception {
    }

    @After
    public void tearDown() throws Exception {
    }

    // Ensure that the most basic task of all can be passed:
    // the initialization of a mock object
    @Test
    public void canCreateMockObject(){
        MockObject obj = new MockObject();
        assertEquals("Incorrect value for Game Active", true, obj.getGameStatus());
        assertEquals("Incorrect RayCast Value", false, obj.getRayCast());
        assertEquals("Incorrect Audio Value", false, obj.getAudio());
    }

    // as to not re-use code throughout the remaining tests,
    // a mock object is defined and instantiated right now...
    private MockObject obj = new MockObject();

    // THE FOLLOWING UNIT TESTS ARE INTENDED TO BE SELF-EXPLANATORY,
    // THEREFORE, NO MORE COMMENTS WILL BE PROVIDED TO EXPLAIN WHAT
    // IS BEING DONE FROM THIS POINT FORWARD

    @Test
    public void canDetectInput(){
        obj.performRayCast();
        assertEquals("Invlad Ray Cast Value", true, obj.getRayCast());
    }

    @Test
    public void canDetectInput2(){
        obj.performAudioStatement();
        assertEquals("Invalid Audio Value", true, obj.getAudio());
    }

    @Test
    public void canGetCoordinateValues(){
        assertEquals("Invlaid X Cord", 0, obj.getxCord());
        assertEquals("Invlaid Y Cord", 0, obj.getyCord());
        assertEquals("Invlaid Z Cord", 0, obj.getzCord());
    }

    @Test
    public void canSetCoordinateValues(){
        obj.setCoordinates(2, 4, 6);
        assertEquals("Invlaid X Cord", 2, obj.getxCord());
        assertEquals("Invlaid Y Cord", 4, obj.getyCord());
        assertEquals("Invlaid Z Cord", 6, obj.getzCord());
    }

    @Test
    public void canPrintOutCoordinateValues(){
        assertEquals("Invalid String printed out", "(0, 0, 0)", obj.getCoordinates());
        obj.setCoordinates(2,4,6);
        assertEquals("Invalid String printed out", "(2, 4, 6)", obj.getCoordinates());
        obj.setCoordinates(6,2,4);
        assertEquals("Invalid String printed out", "(6, 2, 4)", obj.getCoordinates());
        obj.setCoordinates(1,2,3);
        assertEquals("Invalid String printed out", "(1, 2, 3)", obj.getCoordinates());
        obj.setCoordinates(6,6,6);
        assertEquals("Invalid String printed out", "(6, 6, 6)", obj.getCoordinates());
        obj.setCoordinates(0,0,0);
        assertEquals("Invalid String printed out", "(0, 0, 0)", obj.getCoordinates());
    }

    @Test
    public void canTranslateObjectInXDirection(){
        assertEquals("Invalid X Cord", 0, obj.getxCord());
        obj.translateX(30);
        assertEquals("Invalid X Cord", 30, obj.getxCord());
        obj.translateX(-30);
        assertEquals("Invalid X Cord", 0, obj.getxCord());
        obj.translateX(100);
        assertEquals("Invalid X Cord", 100, obj.getxCord());
        obj.translateX(-100);
        assertEquals("Invalid X Cord", 0, obj.getxCord());
        obj.translateX(0);
        assertEquals("Invalid X Cord", 0, obj.getxCord());
        obj.translateX(-100);
        assertEquals("Invalid X Cord", -100, obj.getxCord());
    }

    @Test
    public void canTranslateObjectInYDirection(){
        assertEquals("Invalid Y Cord", 0, obj.getyCord());
        obj.translateY(30);
        assertEquals("Invalid Y Cord", 30, obj.getyCord());
        obj.translateY(-30);
        assertEquals("Invalid Y Cord", 0, obj.getyCord());
        obj.translateY(100);
        assertEquals("Invalid Y Cord", 100, obj.getyCord());
        obj.translateY(-100);
        assertEquals("Invalid Y Cord", 0, obj.getyCord());
        obj.translateY(0);
        assertEquals("Invalid Y Cord", 0, obj.getyCord());
        obj.translateY(-100);
        assertEquals("Invalid Y Cord", -100, obj.getyCord());

    }

    @Test
    public void canTranslateObjectInZDirection(){
        assertEquals("Invalid Z Cord", 0, obj.getzCord());
        obj.translateZ(30);
        assertEquals("Invalid Z Cord", 30, obj.getzCord());
        obj.translateZ(-30);
        assertEquals("Invalid Z Cord", 0, obj.getzCord());
        obj.translateZ(100);
        assertEquals("Invalid Z Cord", 100, obj.getzCord());
        obj.translateZ(-100);
        assertEquals("Invalid Z Cord", 0, obj.getzCord());
        obj.translateZ(0);
        assertEquals("Invalid Z Cord", 0, obj.getzCord());
        obj.translateZ(-100);
        assertEquals("Invalid Z Cord", -100, obj.getzCord());
    }

    @Test
    public void complexTranslationOne(){
        obj.translateX(30);
        obj.translateY(-45);
        obj.translateZ(73);
        assertEquals("Invalid Coordinates", "(30, -45, 73)", obj.getCoordinates());
    }

    @Test
    public void complexTranslationTwo(){
        obj.translateX(30);
        obj.translateY(-45);
        obj.translateZ(73);
        obj.translateX(-100);
        obj.translateY(33);
        obj.translateZ(1000);
        assertEquals("Invalid Coordinates", "(-70, -12, 1073)", obj.getCoordinates());
    }

    @Test
    public void canRotateX(){
        obj.rotateX(45);
        assertEquals("Invalid X Angle", 45, obj.getxAngle());
        obj.rotateX(45);
        assertEquals("Invalid X Angle", 90, obj.getxAngle());
        obj.rotateX(-180);
        assertEquals("Invalid X Angle", -90, obj.getxAngle());
        obj.rotateX(45);
        assertEquals("Invalid X Angle", -45, obj.getxAngle());
        obj.rotateX(45);
        assertEquals("Invalid X Angle", 0, obj.getxAngle());
    }

    @Test
    public void canRotateY(){
        obj.rotateY(45);
        assertEquals("Invalid Y Angle", 45, obj.getyAngle());
        obj.rotateY(45);
        assertEquals("Invalid Y Angle", 90, obj.getyAngle());
        obj.rotateY(-180);
        assertEquals("Invalid Y Angle", -90, obj.getyAngle());
        obj.rotateY(45);
        assertEquals("Invalid Y Angle", -45, obj.getyAngle());
        obj.rotateY(45);
        assertEquals("Invalid Y Angle", 0, obj.getyAngle());
    }

    @Test
    public void complexRotateX(){
        obj.rotateX(370);
        assertEquals("Invalid X Angle", 10, obj.getxAngle());
        obj.rotateX(-370);
        assertEquals("Invlaid X Angle", 0, obj.getxAngle());
        obj.rotateX(-370);
        assertEquals("Invlaid X Angle", -10, obj.getxAngle());
    }

    @Test
    public void complexRotateY(){
        obj.rotateY(370);
        assertEquals("Invalid Y Angle", 10, obj.getyAngle());
        obj.rotateY(-370);
        assertEquals("Invlaid Y Angle", 0, obj.getyAngle());
        obj.rotateY(-370);
        assertEquals("Invlaid Y Angle", -10, obj.getyAngle());
    }

    @Test
    public void canPrintOutAngles(){
        obj.rotateX(35);
        obj.rotateY(-75);
        assertEquals("Invalid Angles Given", "x: 35 degrees, y: -75 degrees", obj.printAngles());
    }

    @Test
    public void complexRotation(){
        obj.rotateX(388);
        obj.rotateY(-15);
        obj.rotateX(22);
        obj.rotateY(33);
        assertEquals("Invalid Angles Given", "x: 50 degrees, y: 18 degrees", obj.printAngles());
    }

    @Test
    public void canBloomToTerminate(){
        obj.bloom();
        assertEquals("Invalid value for game status", false, obj.getGameStatus());
    }

    @Test
    public void canResetObjValues(){
        obj.performRayCast();
        obj.performAudioStatement();
        obj.setCoordinates(3,6,9);
        obj.bloom();
        obj.resetObj();
        assertEquals("Incorrect Value for Game Status", true, obj.getGameStatus());
        assertEquals("Incorrect Audio Value", false, obj.getAudio());
        assertEquals("Incorrect Ray Cast Value", false, obj.getRayCast());
        assertEquals("Invalid X Cord", 0, obj.getxCord());
        assertEquals("Invalid Y Cord", 0, obj.getyCord());
        assertEquals("Invalid Z Cord", 0, obj.getzCord());
        assertEquals("Invalid X Angle", 0, obj.getxAngle());
        assertEquals("Invalid Y Angle", 0, obj.getyAngle());
    }
}//END AUTOMATED TESTS