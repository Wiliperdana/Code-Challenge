const readline = require("readline");

const kamus = {
    'A': 0, 'B': 1, 'C': 1, 'D': 1, 'E': 2, 'F': 3, 'G': 3, 'H': 3,
    'I': 4, 'J': 5, 'K': 5, 'L': 5, 'M': 5, 'N': 5, 'O': 6, 'P': 7,
    'Q': 7, 'R': 7, 'S': 7, 'T': 7, 'U': 8, 'V': 9, 'W': 9, 'X': 9,
    'Y': 9, 'Z': 9, 'a': 9, 'b': 8, 'c': 8, 'd': 8, 'e': 7, 'f': 6,
    'g': 6, 'h': 6, 'i': 5, 'j': 4, 'k': 4, 'l': 4, 'm': 4, 'n': 4,
    'o': 3, 'p': 2, 'q': 2, 'r': 2, 's': 2, 't': 2, 'u': 1, 'v': 0,
    'w': 0, 'x': 0, 'y': 0, 'z': 0, ' ': 0
};

function task1(sentence) {
    return Array.from(sentence).reduce((result, char) => {
        return kamus.hasOwnProperty(char) ? result + kamus[char] : result;
    }, "");
}

function task2(sentence) {
    const values = Array.from(sentence).map((char) =>
        kamus.hasOwnProperty(char) ? kamus[char] : 0
    );

    let result = values[0] || 0;
    for (let i = 1; i < values.length; i++) {
        if (i % 2 === 0) {
            result -= values[i];
        } else {
            result += values[i];
        }
    }
    return result;
}

function task3(target) {
    const numbers = [];
    let currentSum = 0;
    let nextNumber = 0;

    while (currentSum < target) {
        if (currentSum + nextNumber > target) {
            nextNumber = 0;
        }
        numbers.push(nextNumber);
        currentSum += nextNumber;
        nextNumber++;
    }
    return numbers;
}

function task4(values) {
    const transformedValues = [...values];
    if (transformedValues.length >= 2) {
        transformedValues[transformedValues.length - 2] += 1;
        transformedValues[transformedValues.length - 1] += 1;
    }
    return transformedValues;
}

function task5(letters) {
    const values = Array.from(letters).map((char) =>
        kamus.hasOwnProperty(char) ? kamus[char] : null
    );
    return values.map((value) =>
        value !== null && value % 2 === 0 ? value + 1 : value
    );
}

function convertNumbersToLetters(numbers) {
    const reverseKamus = Object.entries(kamus).reduce((acc, [char, value]) => {
        if (!acc[value]) acc[value] = char;
        return acc;
    }, {});

    return numbers.map((num) => reverseKamus[num]).join(" ");
}

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

rl.question("Masukkan kalimat: ", (input) => {
    const resultTask1 = task1(input);
    const resultTask2 = task2(input);
    const resultTask3 = task3(Math.abs(resultTask2));
    const resultLettersTask3 = convertNumbersToLetters(resultTask3);
    const resultTask4 = task4(resultTask3);
    const resultLettersTask4 = convertNumbersToLetters(resultTask4);
    const resultTask5 = task5(resultLettersTask4.split(" "));

    console.log(`Task 1: ${resultTask1}`);
    console.log(`Task 2: ${resultTask2}`);
    console.log(`Task 3: ${resultLettersTask3}`);
    console.log(`Task 4: ${resultLettersTask4}`);
    console.log(`Task 5: ${resultTask5.join(" ")}`);

    rl.close();
});