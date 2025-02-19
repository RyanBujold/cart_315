# Process Journal

## Tiny Game | 23/01/2025
![game screenshot](./Media/unlok_screenshot.png)

[Game Link](../Projects/UnLok.html)

### Thoughts:
- I decided to do a puzzle game with puzzle script engine since I found the game "bloom" very enjoyable to mess around with
- I somehow managed to make the editor stop working
- It turned out to be some syntax bug with words not capitalized 
- I used the game's documentation and took some commands from there to create the basic puzzle idea
- Then I just started messing around with making levels using the mechanics
- Added the mole and had a lot of difficulty setting it up since you couldn't pass through it without killing you
- Decided that the mole moves similarly to the player to make for a more interesting obstacle
- Found that moving into walls was the dominant strategy to solve most puzzles and invalidated the mole's challenge often 
- Added spikes to make this way more challenging
- The mole could delete not only enemies but also the win flag
- So I used this as the gimmick for the final level
- The later levels with the mole onwards are buggy and not well balanced

### Playtest notes: 
- everyone liked the game and found it very challenging
- Someone who likes puzzle games specifically really enjoyed it

## Exploration Prototype 1
- I forgot to work on this. I think that my goals going forward will be to not forget again and mess around to find something interesting to turn the prototype into. 

## Exploration Prototype 2
- Starting with the pong template
- Modified the paddle's movement to scale to time passed (delta time)
- Thinking about the game "Cube Slam" and how it made pong fun and interesting. Might steal some ideas from it
- I made a new script for an AI paddle opponent that simply follows where the ball goes. This would mimic "Cube Slam"'s opponent.
- Next I started implementing moving walls. There was trouble when on start, it kept placing the object at the orgin instead of where I defined it.
- After some detective work, I found that my code was reseting the position to (0,0,0) on the first frame because the initial x and y position that were being used in the transform were starting at 0.
- I added variable angles to when the ball bounces off the paddles. It took a lot of math to figure out what exactly I wanted. 
- Basically, I wanted the balls to travel at an angle based on where it bounced on the paddle. So I would take the distance between the ball's y and the paddle's y and combine them together to get the steepness of our new tragectory 'a'. That would fit into the formula y=ax. Then I also wanted to make sure that the velocity was consistent at said angles. So I said that s=x+y, 's' being the ball speed. Eventually, I formulated formulas to find 'x' and 'y' coordinates that would satify both with x = s/(a+1) and y = (a*s)/(a+1). 
- After all the math, I got something that worked somewhat. I thinks it didn't exacly turn out how I thought it would. But it still works nicely to control the ball's angle. Which was the end goal. So at this point I'm satisfied with the result.
- I wanted to add text displaying the score as the finishing touch but I think that would a bit much here.
- I'm not sure what else I would want to add except maybe more levels with different wall variations? The wall movement is definitely flexible enough for something like that.

## Exploration Prototype 3
![breakout game screenshot](./Media/breakout_screenshot.png)
- I had this idea to take the breakout blocks and make them fall and stack when hit
- My next thought would be how would the ball fall out of bounds if the fallen bricks stopped them? So I decided there should be another fail condition like a time limit to hit all the other blocks. 
- I then imagined that you would be able to platform on top of the falling blocks. So I created paddle guy.
- I gave him unique collision and gave him a jump. The physics were strange and would knock himself over. But instead of locking the rotation, I imagine that it would be more interesting to have a backwards jump to reposition yourself instead.
- The bricks have been modified into "fall bricks". When the ball hits them, their physics activate, they fall to the ground and change color.
- I used the game manager to track how many bricks we need to hit to win the game and how many bricks have been hit to create a win condidion.
- Once you win, you get the total time in seconds passed as your high score. Now the game is a time trial to compete against other's high scores.

## Exploration Prototype 3 - Continued
- If the question behind the first part of this prototype was "how can I make breakout with falling blocks?", my next question is "How can I make the mechanics more interesting".
- Once the blocks fall, they act as platforms. However, the player can basically fly and blow right through them. 
- I modified the bricks so that they have more mass and move around less when pushed by the player. I also got rid of the paddle guy's backwards jump because it was not only un-intuitive, without it the player has to work to flip the paddle right side up in order to use their jump ability again, adding depth.
- I gave the paddle guy's jump a cooldown so that you can no longer fly around. The paddle guy's color darkens to show when the jump is on cooldown.
- I added some simple ui to show the timer that tracks how long it took to beat the level. I also put a goal time. This would keep the high score mechanic while also creating an initial challenge to beat.
- Also added a simple out of bounds checker for the ball. If its traveling somewhere too far out of the game, it will reset.
- I found that it was too easy to fall over and too difficult to put yourself upright. So I added buttons that can rotate the paddle guy left and right. The paddle guy also now has more detailed collision, making him a bit harder to keep upright.
- When the game starts, you can jump into the ball and mess up everything before pressing space to launch it. So I made it that the paddle guy can't jump before space is pressed. The timer also doesn't start until the ball launches.

## Extra Credit Game Analysis
