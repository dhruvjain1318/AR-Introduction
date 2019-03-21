### INFO 5340 / CS 5650
### Virtual and Augmented Reality 
# Assignment 0

Read: [Assignment Instructions](https://docs.google.com/document/d/1u9eCKspERhOQdH5Uw3BRDCHFSyydmr2SG5bcwxrp5YQ/edit?usp=sharing "Detailed Assignment Instructions")

<hr>

### Student Name:

Dhruv Jain

### Student Email:

dj336@cornell.edu

### Solution (Screen Recording):

https://youtu.be/zM9TX0_KPWc

### Work Summary:

I first created the reference from the scene controller to the simple animator to link the TextMesh's animator to the scene controller. I then put in the event listener to listen for button clicks, which would then initialize the movetowardsonclick script. That script picked a random location, set it to a destination data structure, and shipped that over to the simple animator along with a movement speed.

The simple animator scripts awakens in the default state. When Start Animation is triggered it will move the state machine into the move towards state. That uses the destination values and the movetowards unity function to move towards that point. It probes its current location as it moves. When it see that its current position matches its destination, it will move into the rotation state. The rotation will occur at the specified speed, while decrementing from 360, to only perform one spin. As it nears the end of its rotation and sees that its next step would overshoot a 360 spin, it sets itself to 0.
