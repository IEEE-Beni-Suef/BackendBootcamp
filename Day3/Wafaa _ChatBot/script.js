async function sendMessage() {
    const input = document.getElementById("userInput").value;
    const responseDiv = document.getElementById("response");

    if (!input) {
        responseDiv.innerText = "Please type a question 😊";
        return;
    }

    responseDiv.innerText = "Thinking... 🤔";

    const API_KEY = "AIzaSyDLMJARxMYqUt4Tl8ADjPPPB1m672tTVmY";

    const url = `https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=${API_KEY}`;

    const body = {
        contents: [
            {
                parts: [{ text: input }],
            },
        ],
    };

    try {
        const res = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(body),
        });

        const data = await res.json();
        const botReply = data.candidates?.[0]?.content?.parts?.[0]?.text;

        responseDiv.innerText = botReply || "Couldn't reply 😢";
    } catch (err) {
        responseDiv.innerText = "Error: " + err.message;
    }
}
