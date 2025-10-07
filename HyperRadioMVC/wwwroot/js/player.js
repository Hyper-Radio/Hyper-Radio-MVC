document.addEventListener("DOMContentLoaded", () => {
    const audio = document.getElementById("radio");
    const playBtn = document.getElementById("play-btn");
    const pauseBtn = document.getElementById("pause-btn");
    const volume = document.getElementById("volume");

    // Play / Pause Controls
    playBtn.addEventListener("click", () => {
        audio.play();
        playBtn.classList.add("hidden");
        pauseBtn.classList.remove("hidden");
    });

    pauseBtn.addEventListener("click", () => {
        audio.pause();
        pauseBtn.classList.add("hidden");
        playBtn.classList.remove("hidden");
    });

    // Volume control
    volume.addEventListener("input", (e) => {
        audio.volume = e.target.value;
    });

    // Optional: reset buttons when song ends
    audio.addEventListener("ended", () => {
        pauseBtn.classList.add("hidden");
        playBtn.classList.remove("hidden");
    });
});