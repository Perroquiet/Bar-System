/** 
 * Elevator.java
 *
 * Version:
 *     $Id$
 *
 * Revisions:
 *     $Log$
 */

import java.util.*;

/**
 * This program simulates the operation of a single elevator.
 * Elevators run between the first and second floors of an office
 * building.
 *
 *
 * The elevator will depart when full (currently 10 passengers)
 * or when a delay timer has expired (currently 10 ticks).
 *
 * At the end of the day, the elevators stop running.  If passengers
 * have boarded the elevator but never make the trip, an appropriate
 * message is displayed.
 */

public class Elevator {

    // constants to represent the 2 floors in the building
    private static final int FIRST_FLOOR = 1;   // constant for 1st floor
    private static final int SECOND_FLOOR = 2;  // constant for 2nd floor

    private byte identifier;         // elevator number
    private byte passengerCount;     // count of people currently in elevator
    private byte currentFloor;       // elevator is currently on this floor
    private byte timeLeftToDeparture;// number of ticks until elevator departs
	private byte totalPassengerCount; //edited by MAGNUM

    // Constructors

    /**
     * Constructor for Elevator object
     *
     * @param    elevatorNumber    Unique identifier for this elevator
     *
     * @return   returns new Elevator object
     *
     */

    public Elevator( byte elevatorNumber ) {
        identifier = elevatorNumber;  // unique ID for this elevator
    
        //  set defaults for this elevator
        //  elevator starts empty on 1st floor
	//  and will wait for 10 time units
        passengerCount = 0;        
        currentFloor = FIRST_FLOOR; 
        timeLeftToDeparture = 10;  
    } //  end constructor

    // public methods for this class
    //
	
    //  Display this object.  Used for debug only.

    /**
     * Print method for Elevator object.
     * Used for debugging only.
     *
     */
		
    public void print() {
        System.out.println( " This is elevator # " + identifier );
    } //  end print

    /**
	 * Return total number of passengers for this object
	 *
	 * @return the totalPassengerCount
	 * created by MAGNUM
	 */
	
	public byte getTotalPassengers() {
		return totalPassengerCount;
	}
	
	/**
     * Return identifier (elevator number) for this object
     *
     * @return the identifier (elevator number) of this object
     */

    public byte getIdentifier() {
        return identifier;
    } //  end getIdentifier

    /**
     * Simulates passage of one time unit
     *
     */

    public void tick() {
        if ( timeToDepart() )  {
            elevatorDeparts();
            resetPassengerCount();
            timeLeftToDeparture = 10;
        }
        timeLeftToDeparture--;
    } //  end tick

    /**
     * Returns current passenger count
     *
     * @return  current passengerCount for this elevator
     *
     */

     public byte getPassengerCount() {
         return passengerCount;
     } //  end getPassengerCount

    /**
     * Determines if elevator is on the same
     * floor as passenger newPass.
     *
     * @param    newPass passenger object representing
     *           new passenger
     *
     * @return   true if elevator is on the same floor as 
     *           this passenger; otherwise false.
     *
     */

    public boolean isElevatorHere ( Passenger newPass ) {
        return ( newPass.getFloor() == currentFloor );
    } //  end isElevatorHere

    /**
     * Adds passenger to this elevator
     *
     * @param    newPass passenger representing
     *           new passenger
     *
     * @return   true if passenger was successfully added
     *           to elevator; otherwise false.
     *
     */

    public boolean addPassenger( Passenger newPass ) {
        boolean flag = true;
       if( passengerCount >=  10 )  {
            System.out.println( "Error:  Too many people in elevator" );
            flag = false;
        } else {
            passengerCount++;
			totalPassengerCount++; //edited by MAGNUM

            // if time for the elevator to leave, display the message,
            // change the current floor, reset passenger count to 0
            // and start waiting for 10 time ticks at the new floor 

            System.out.println ( " Loaded into Elevator " + identifier + "." );

            if( elevatorFull() ) {
                elevatorDeparts();
                resetPassengerCount();
                timeLeftToDeparture = 10;
            }
        }
        return flag;
    } //  end addPassenger

    //  Private methods used only within this class
    //

    /**
     * See if time delay has expired
     *
     * @return   True or False to indicate if timer is at 0
     *
     */

    private boolean timeToDepart() {
		//return ( timeLeftToDeparture == 0 );
        return ( timeLeftToDeparture == 1 ); 
		//edited by MAGNUM
    } //  end timeToDepart

    /**
     * Resets passenger count to 0    
     *
     */

    private void resetPassengerCount() {
        passengerCount = 0;
    } //  end resetPassengerCount 

    /**
     * Announces the elevator's departure to the other floor
     * and sends a message to the elevator to change the
     * current floor.
     *
     */

    private void elevatorDeparts() {
        System.out.println( "Elevator " + identifier + " departing for " +
                            formatDestinationFloor() + " floor with " + 
                            passengerCount + formatPassengerCount() + "." );

        changeFloors();
    } //  end elevatorDeparts

   /**
     * Simulates the elevator's change to the other floor
     *
     */

    private void changeFloors() {
        if( currentFloor == FIRST_FLOOR ) {
            currentFloor = SECOND_FLOOR;
        } else {
            currentFloor = FIRST_FLOOR;
        }
    } //  end changeFloors

   /**
     * Determines if the elevator is full                     
     *
     * @return true if passenger count at capacity; otherwise false.
     *
     */

    private boolean elevatorFull() {
        //return ( passengerCount >= 10 ); 
		return ( passengerCount >= 8 ); 
		//edited by MAGNUM
    } //  end elevatorFull

    /**
     * Formats the destination floor for printing
     *
     * @return   String containing appropriate
     *           floor.
     *
     */

    private String formatDestinationFloor (){
	String retVal = "1st";
        if( currentFloor == 1 ) {
            retVal =  "2nd" ;
	}      
        return retVal;
    } //  end formatDestinationNumber   

    /**
     * Formats a string literal for printing
     *
     * @return   String containing singular/plural
     *           "passenger/passengers"
     *
     */

    private String formatPassengerCount() {
	String retVal = " passengers";
        if( passengerCount == 1 ) {
            retVal = " passenger" ;
	}      
        return retVal;
    } //  end formatPassengerCount

} //  Elevator
