// VARIABLE DECLARATIONS

/* STEP 1: Declare and initialize variables
- customName for the name field
- randomize for the button
- story for the paragraph that outputs the final story
*/

/* STEP 3: Create the variable that contains the story string that will be modified 
- use var storyText to containt the following:
'It was 94 farenheit outside, so :insertx: went for a walk. When they got to :inserty:, they stared in horror for a few moments, then :insertz:. Bob saw the whole thing, but he was not surprised — :insertx: weighs 300 pounds, and it was a hot day.'
*/


/* STEP 4: Create three arrays, insertX, insertY, and insertZ, assigning them the following array values respectively:
Donald Trump, Jackie Chan, Santa Claus
Area 51, Death Valley, Aruba
spontaneously combusted, rapidly sublimated, evaporated instantly
*/

// FUNCTIONS

/* STEP 2: have a look at the following function - if you call this function and pass it an array, it will return one of the elements of that array randomly */
/* STEP 6: Review the partially complete result() function below */

// EVENT LISTENER
    // STEP 7: Create a new variable called newStory and 
    //set it to the value of storyText - we don't want to overwrite the original story!
    
    /* STEP 8: Use the randomValueFromArray() function to generate a value for 
    each of three new variables - xItem, yItem, and zItem
	Call up the function and for each variable, pass it the array from 
    which to grab a random string - for example if insertW was an array of strings, I would type:
	var wItem = randomValueFromArray(insertW);*/
    
    //console.log(xItem);
    /* STEP 9: Replace the three placeholders in the newStory 
    string — :insertx:, :inserty:, and :insertz: — with the strings stored in 
    xItem, yItem, and zItem. Each time, be sure to update the variable newStory 
    (with =). You might need to do one of the above replacements twice! */
    

    /* STEP 10: If the user has typed a name in the customName field, replace the name 'Bob' in the story with whatever they typed */
    
    /* STEP 11: If the metric radio button has been checked, we need to convert the temperature and mass numbers in the story */
        // STEP 11a: Create a variable called weight and convert the 300lbs to kgs (1lb = 0.453592kg)
        
        // STEP 11b: Replace the string 300 pounds with the updated weight in kg
        
        // STEP 12a: Create a variable called temp and convert °F to °C ... the formula for conversion is °C = (°F - 32) x 5/9
        
        // STEP 12b: Replace the string '94 fahrenheit' with the updated temperature in °C

    /* STEP 13: Make the textContent property of the story variable (which references the paragraph) equal to newStory */
    
    // The following line makes the paragraph visible


// EVENT LISTENERS
/* STEP 5: Add a click event listener to the randomize variable 
so that when the button it represents is clicked, the result() function is run. */

// This lab based on the excellent assessment challenge at https://developer.mozilla.org/en-US/docs/Learn/JavaScript/First_steps/Silly_story_generator
// VARIABLE DECLARATIONS
const customName = document.getElementById("customName");
const randomize = document.querySelector(".randomize");
const story = document.querySelector(".story");

const storyText =
    "It was 94 fahrenheit outside, so :insertx: " +
    "went for a walk. When they got to :inserty:, " +
    "they stared in horror for a few moments, then :insertz:. " +
    "Bob saw the whole thing, but he was not surprised — :insertx: " +
    "weighs 300 pounds, and it was a hot day.";

const insertX = ["Donald Trump", "Jackie Chan", "Santa Claus"];
const insertY = ["Area 51", "Death Valley", "Aruba"];
const insertZ = [
    "spontaneously combusted",
    "rapidly sublimated",
    "evaporated instantly",
];

// FUNCTIONS
function randomValueFromArray(array) {
    return array[Math.floor(Math.random() * array.length)];
}

function result() {
    let newStory = storyText;

    const xItem = randomValueFromArray(insertX);
    const yItem = randomValueFromArray(insertY);
    const zItem = randomValueFromArray(insertZ);

    newStory = newStory.replaceAll(":insertx:", xItem);
    newStory = newStory.replaceAll(":inserty:", yItem);
    newStory = newStory.replaceAll(":insertz:", zItem);

    if (customName.value !== "") {
        const name = customName.value;
        newStory = newStory.replace("Bob", name);
    }

    if (document.getElementById("metric").checked) {
        const weight = Math.round(300 * 0.453592) + " kilograms";
        const temperature = Math.round(((94 - 32) * 5) / 9) + " centigrade";

        newStory = newStory.replace("300 pounds", weight);
        newStory = newStory.replace("94 fahrenheit", temperature);
    }

    story.textContent = newStory;
    story.style.visibility = "visible";
}

// EVENT LISTENER
randomize.addEventListener("click", result);
