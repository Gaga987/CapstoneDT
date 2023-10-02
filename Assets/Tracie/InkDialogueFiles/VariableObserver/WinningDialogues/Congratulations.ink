INCLUDE WinningGlobals.INK

{winningtopics == "" : -> congratulationsmain | -> crowdoutcomes}


=== congratulationsmain === 
Chosen One! Congratulations! You have proven valorant and freed us all from the shadows that plagued herein! Let us repay you! 

+[don't worry about it! its on the house!]
I don't need payment!
-> followup ("Really? The Spear of Deliverance! is the legendary weapon of the realm!" )

+[Repay me how?] 
What do you got?
-> followup (" With the Spear of Deliverance of course! Riser, the Mystic, who saved us long ago... left the Spear in the care of Demorious - the realms oracle.") 





=== followup(choices) ===
~winningtopics = choices 
 {choices} We mustn't accept charity. Please do take the Spear of Deliverance !  
-> END 


===crowdoutcomes === 
Thank you for all of your help! It is our honor to bestow our sacred relic upon you. May your life be filled with pleasures  long after you leave us {winningtopics}! 
-> END 