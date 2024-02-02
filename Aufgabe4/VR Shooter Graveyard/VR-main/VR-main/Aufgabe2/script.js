document.addEventListener("DOMContentLoaded", function () {
  document.getElementById("startButton").addEventListener("click", function () {
    const carElement = document.querySelector(".car");
    // Remove the car-moving class to reset the animation
    carElement.classList.remove("car-moving");
    // Using setTimeout to force browser reflow and restart the animation
    setTimeout(() => {
      carElement.classList.add("car-moving");
    }, 10); // 10ms is just a short delay to ensure the browser has time to reflow
  });

  /*document.getElementById("clearButton").addEventListener("click", function () {
    const timeInSeconds = parseInt(document.getElementById("timeInput").value);
    document.body.style.transitionDuration = `${timeInSeconds}s`;
    document.body.classList.add("hidden");
    setTimeout(() => {
      document.body.innerHTML = "";
    }, timeInSeconds * 1000);
  });*/
  document.getElementById("clearButton").addEventListener("click", function () {
    const timeInSeconds = parseInt(document.getElementById("timeInput").value);
    document.body.style.transition = `opacity ${timeInSeconds}s`;
    document.body.style.opacity = 0;
    setTimeout(() => {
      document.body.innerHTML = "";
    }, timeInSeconds * 1000);
  });
});
