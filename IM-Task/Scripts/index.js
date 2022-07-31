let jsInputField = document.querySelector("#js-input");
let cButton = document.querySelector("#c-button");
let cInputField = document.querySelector("#c-input");
let sqlInputField = document.querySelector("#sql-input");
let sqlButton = document.querySelector("#sql-button");

const updateInputColor = (inputElement, isPalindrome) => {
    if (isPalindrome)
        inputElement.style.backgroundColor = "Green";
    else
        inputElement.style.backgroundColor = "Red";
}


const IsPalindrome = (e) => {
    let text = e.target.value;
    // remove white spaces
    text = text.replaceAll(" ", "");
    // turn text to lower case to make sure all characters are lower case
    text = text.toLowerCase();
    // reverse text and compare to see if its' a palindrome
    // there is another way to check if the text is palindrome but will use it in c# to show case all possible solutions
    let reversedText = text.split("").reverse().join("");

    if (text == reversedText)
        return true;
    else
        return false;
}

// sends request to IsPalindrome endpoint that evaluates the string by c# algortihm
const SendIsPalinromeReuqest = async (text) => {

    const body = JSON.stringify(text);
    try {
        const response = await fetch("api/Palindrome/IsPalindrome", {
            method: "Post",
            body: body,
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return await response.json();
    } catch (error) {
        console.log(error);
    }
}

// sends request to IsPalindromeSql endpoint that evaluates the string by sql query
const SendIsPalindromeSqlRequest = async (text) => {
    const body = JSON.stringify(text);
    try {
        const response = await fetch("api/Plaindrome/IsPalindromeSql", {
            method: "Post",
            body: body,
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return await response.json();
    } catch (error) {
        console.log(error);
    }
}



jsInputField.addEventListener("input", (e) => {
    updateInputColor(jsInputField, IsPalindrome(e));
});



cButton.addEventListener("click", async (e) => {
    let isPalindrome = await SendIsPalinromeReuqest(cInputField.value);
    updateInputColor(cInputField, isPalindrome);

});

sqlButton.addEventListener("click", async (e) => {
    let isPalindrome = await SendIsPalindromeSqlRequest(sqlInputField.value);
    updateInputColor(sqlInputField,isPalindrome)
})



