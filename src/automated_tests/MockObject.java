/*
 * Created by Stephen White on 4/19/2017.
 *
 * This class is intended to model a mock object, in this case,
 * the Microsoft Hololens. The methods are intended to be self
 * explanatory, therefore comments will be left to a minimum.
 */

public class MockObject {
    // each instance of this mock object has the following attributes...
    private boolean gameStatus;
    private boolean rayCast;
    private boolean audio;
    private int xCord;
    private int yCord;
    private int zCord;
    private int xAngle;
    private int yAngle;

    // initilize the object with a constructor
    public MockObject(){
        resetObj();
    }

    // allow for resetting of of all attributes at once
    public void resetObj(){
        gameStatus = true;
        rayCast = false;
        audio = false;
        xCord = 0;
        yCord = 0;
        zCord = 0;
        xAngle = 0;
        yAngle = 0;
    }

    // See if the game is active or not
    public boolean getGameStatus(){
        return gameStatus;
    }

    // The "bloom" gesture exits the application
    public void bloom(){
        gameStatus = false;
    }

    // upon pinching or tapping, a ray cast is performed
    private void setRayCast(){
        rayCast = !rayCast;
    }

    // allows for the toggling of audio clips
    private void setAudio(){
        audio = !audio;
    }

    // see whether a ray cast is currently being performed or not
    public boolean getRayCast(){
        return this.rayCast;
    }

    // see if an audio command was registered or not
    public boolean getAudio(){
        return this.audio;
    }

    // set the X coordinate in 3D space
    private void setxCord(int cord){
        xCord = cord;
    }

    // obtain the x coordinate in 3D space
    public int getxCord(){
        return xCord;
    }

    // set the y coordinate in 3D space
    private void setyCord(int cord){
        yCord = cord;
    }

    // get the y coordinate in 3D space
    public int getyCord(){
        return yCord;
    }

    // set the z coordinate in 3D space
    private void setzCord(int cord){
        zCord = cord;
    }

    // get the z coordinate in 3D space
    public int getzCord(){
        return zCord;
    }

    // translate the x coordinate in 3D space
    public void translateX(int x){
        xCord += x;
    }

    // translate the y coordinate in 3D space
    public void translateY(int y){
        yCord += y;
    }

    // translate the z coordinate in 3D space
    public void translateZ(int z){
        zCord += z;
    }

    // sett all three coordinates in 3D space at once
    public void setCoordinates(int x, int y, int z){
        setxCord(x);
        setyCord(y);
        setzCord(z);
    }

    // rotate the object n-degrees in the x-direction
    public void rotateX(int degrees){
        xAngle += degrees%360;
    }

    // see at what angle the mock object lies in the x-direction
    public int getxAngle(){
        return xAngle;
    }

    // rotate the object n-degrees in the y-direction
    public void rotateY(int degrees){
        yAngle += degrees%360;
    }

    // see at what angle the mock object lies in the y-direction
    public int getyAngle(){
        return yAngle;
    }

    // be able to properly print out the angles of this object
    public String printAngles(){
        return String.format("x: %d degrees, y: %d degrees", getxAngle(), getyAngle());
    }

    // be able to properly see all coordinates of this object in 3D space
    public String getCoordinates(){
        return String.format("(%d, %d, %d)", getxCord(), getyCord(), getzCord());
    }

    // toggle a ray cast
    public void performRayCast(){
        setRayCast();
    }

    // toggle the recognition of an audio command
    public void performAudioStatement(){
        setAudio();
    }
}
