document.getElementById('joinForm').addEventListener('submit', function(event){
    event.preventDefault();

    // Simple form validation or data handling here
    var name = document.getElementById('name').value;
    var email = document.getElementById('email').value;
    // Add more variables as needed

    // You would typically send this data to a server
    console.log('Name:', name);
    console.log('Email:', email);
    // Log more data as needed

    alert('Thank you for joining Connect Link!');
});

document.addEventListener("DOMContentLoaded", function() {
    const connectLink = document.getElementById("connectLink");

    // Set up the animation interval
    setInterval(function() {
        connectLink.classList.toggle("animated-text");
    }, 1000); // Toggle the class every 5000 milliseconds (5 seconds)
});

// Function to check if an element is in the viewport
function fadeInUp(element) {
    const rect = element.getBoundingClientRect();
    return (
        rect.top <= (window.innerHeight || document.documentElement.clientHeight)
    );
}

// Function to run on scroll
function runOnScroll() {
    document.querySelectorAll('#reasons div, form, .bottom').forEach((elem) => {
        if (fadeInUp(elem)) {
            elem.classList.add('animate-on-scroll');
        }
    });
}

// Add the scroll event listener
window.addEventListener('scroll', runOnScroll);

/*Right to Left for How to Join*/
document.addEventListener("DOMContentLoaded", function() {
    const joinDivs = document.querySelectorAll("#join div");
    let delay = 0;

    function animateOnScroll() {
        joinDivs.forEach((div) => {
            if (isInViewport(div) && !div.classList.contains('animated')) {
                div.style.animationDelay = `${delay}s`;
                div.classList.add('animate-from-right', 'animated');
                delay += 0.6; // Increase delay for next element
            }
        });
    }

    function isInViewport(element) {
        const rect = element.getBoundingClientRect();
            const offset = 750; // Pixels before the element is fully in view
            return (
                rect.top + offset >= 0 &&
                rect.left >= 0 &&
                rect.bottom - offset <= (window.innerHeight || document.documentElement.clientHeight) &&
                rect.right <= (window.innerWidth || document.documentElement.clientWidth)
            );
    }

    window.addEventListener('scroll', animateOnScroll);
});

//Hamburger Menu
    document.getElementById('hamburger-menu').addEventListener('click', function() {
        var dropdown = document.getElementById('dropdown-menu');
        if (dropdown.style.display === 'block') {
            dropdown.style.display = 'none';
        } else {
            dropdown.style.display = 'block';
        }
    });

//Underline animation
function isInViewport(element) {
    const rect = element.getBoundingClientRect();
    return (
        rect.top >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight)
    );
}
function onScroll() {
    const elements = document.querySelectorAll('.full-width h2');
        elements.forEach(element => {
            if (isInViewport(element)) {
                element.classList.add('active');
            }
        });
    }
window.addEventListener('scroll', onScroll);

gsap.registerPlugin(MotionPathPlugin);

for (let i = 1; i <= 3; i++) {
    gsap.to(`#u-line${i}`, {
        motionPath: {
            path: `#u-line${i}`,
            align: `#u-line${i}`,
            autoRotate: false,
            alignOrigin: [0.5, 0.5]
        },
        duration: 5,
        ease: "power1.inOut",
        repeat: -1,
        yoyo: true
    });
}