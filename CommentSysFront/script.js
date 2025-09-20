const apiBase = "https://localhost:7056/api/comments"; // check correct port!

document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("commentForm");
  const usernameInput = document.getElementById("username");
  const textInput = document.getElementById("text");
  const commentList = document.getElementById("commentList");

  // Load existing comments
  fetch(apiBase)
    .then(res => {
      console.log("GET status:", res.status);
      return res.json();
    })
    .then(comments => {
      console.log("Loaded comments:", comments);
      comments.reverse().forEach(c => addCommentToList(c)); // Ensure newest at top
    })
    .catch(err => console.error("Error loading comments:", err));

  // Submit new comment
  form.addEventListener("submit", (e) => {
    e.preventDefault();
    const username = usernameInput.value.trim();
    const text = textInput.value.trim();

    if (!username || !text) return;

    fetch(apiBase, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, text })
    })
      .then(res => {
        console.log("POST status:", res.status);
        return res.json();
      })
      .then(newComment => {
        console.log("New comment:", newComment);
        addCommentToList(newComment);
        usernameInput.value = "";
        textInput.value = "";
      })
      .catch(err => console.error("Error posting comment:", err));
  });

  function addCommentToList(comment) {
    const li = document.createElement("li");
    li.innerHTML = `<strong>${comment.username}</strong> 
      (${new Date(comment.commentDate).toLocaleString()})<br>${comment.text}`;
    commentList.insertBefore(li, commentList.firstChild); // Add to top
  }
});