<<<<<<< HEAD
import { send } from "clientUtilities";

let selectedCity = "";
let selectedType = "";
let selectedKosher = "";
let searchText = "";


async function selectCity(city: string)
{
    selectedCity = city;

    const cityBtn =
        document.getElementById(
            "cityBtn"
        ) as HTMLButtonElement;

    cityBtn.innerText = city + " ▾";

    await loadRestaurants();
}

async function selectType(type: string)
{
    selectedType = type;

    const typeBtn =
        document.getElementById(
            "typeBtn"
        ) as HTMLButtonElement;

    typeBtn.innerText = type + " ▾";

    await loadRestaurants();
}

async function selectKosher(kosher: string)
{
    selectedKosher = kosher;

    const kosherBtn =
        document.getElementById(
            "kosher"
        ) as HTMLButtonElement;

    kosherBtn.innerText =
        kosher === "true"
            ? "כשר ▾"
            : "לא כשר ▾";

    await loadRestaurants();
}

async function loadRestaurants()
{
    
    const restaurants = await send(
        "getRestaurants"
    );
    console.log(restaurants[0]);

    console.log(restaurants);
    const container =
        document.getElementById(
            "restaurantsContainer"
        ) as HTMLDivElement;

    container.innerHTML = "";

    let filteredRestaurants = restaurants;

    console.log("city: ", selectedCity, "type: ", selectedType, "kosher: ", selectedKosher);

    if (selectedCity !== "")
    {
        console.log(selectedCity);
        filteredRestaurants =
            filteredRestaurants.filter(
                (r: any) => 
                    r.city === selectedCity
            );
    }
   

    if (selectedType !== "")
    {
        filteredRestaurants =
            filteredRestaurants.filter(
                (r: any) => 
                    r.type === selectedType
            );
    } 
 
    

    if (selectedKosher !== "")
    {
        filteredRestaurants =
            filteredRestaurants.filter(
                (r: any) => 
                    String(r.isKosher) === selectedKosher
            );
    }


        if (searchText !== "")
    {
        filteredRestaurants =
            filteredRestaurants.filter(
                (r: any) =>
                    r.name
                    .toLowerCase()
                    .includes(
                    searchText.toLowerCase())
                
        );
}
    
            filteredRestaurants.forEach((r: any) =>
        {
            const card = document.createElement("div");

             card.className = "restaurant-card";

             card.innerHTML = `
    <img src="${r.image}" alt="${r.name}">
    <h2>${r.name}</h2>
    <p>${r.type}</p>
    <p>${r.address}</p>
    <p>⭐ ${r.rating.toFixed(1)}</p>
    <p>${r.isKosher ? " כשר" : " לא כשר"}</p>

    <select id="stars-${r.id}">
        <option value="1">⭐ 1</option>
        <option value="2">⭐ 2</option>
        <option value="3">⭐ 3</option>
        <option value="4">⭐ 4</option>
        <option value="5">⭐ 5</option>
    </select>

    <button class="review-btn">
        דרג
    </button>

    <button class="booking-btn">
        הזמן מקום
    </button>
`;

container.append(card);

const reviewButton =
    card.querySelector(
        ".review-btn"
    ) as HTMLButtonElement;

reviewButton.addEventListener(
    "click",
    () =>
    {
        addReview(r.id);
    }
);

const bookingButton =
    card.querySelector(
        ".booking-btn"
    ) as HTMLButtonElement;

bookingButton.addEventListener(
    "click",
    () =>
    {
        openModal(
            r.id,
            r.name
        );
    }
);

        }       
    );
}


let selectedRestaurantId = 0;
function openModal(
    restaurantId: number,
    restaurantName: string
)
{
    selectedRestaurantId = restaurantId;

    const modal =
        document.getElementById("modal") as HTMLDivElement;

    const modalTitle =
        document.getElementById("modalTitle") as HTMLHeadingElement;

    modalTitle.innerText =
        `הזמנת מקום - ${restaurantName}`;

    modal.style.display = "flex";
}

function closeModal()
{
    const modal =
        document.getElementById(
            "modal"
        ) as HTMLDivElement;

    modal.style.display = "none";
}

loadRestaurants();
async function addReview(restaurantId: number)
{
    alert("restaurantId = " + restaurantId);

    const stars =
        Number(
            (document.getElementById(
                `stars-${restaurantId}`
            ) as HTMLSelectElement).value
        );

    alert("stars = " + stars);

        await send(
            "addReview",
        {
            RestaurantId: restaurantId,
            UserName: "אורח",
            Comment: "",
            Stars: stars
        }
    );
    await loadRestaurants();
}



const searchInput =
    document.getElementById(
        "searchInput"
    ) as HTMLInputElement;

searchInput.addEventListener(
    "input",
    async () =>
    {
        searchText = searchInput.value;
        await loadRestaurants();
    }
);

async function saveBooking()
{
    const bookingDate =
        (document.getElementById(
            "bookingDate"
        ) as HTMLInputElement).value;

    const bookingTime =
        (document.getElementById(
            "bookingTime"
        ) as HTMLInputElement).value;
    alert(selectedRestaurantId);
    alert(bookingDate);
    alert(bookingTime);


    await send(
    "addBooking",
    {
        RestaurantId: selectedRestaurantId,
        BookingDate: bookingDate,
        BookingTime: bookingTime
    }
);
    

    alert("ההזמנה נשמרה");

    closeModal();
}

(document.getElementById(
    "telAvivBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectCity("תל אביב")
);

(document.getElementById(
    "jerusalemBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectCity("ירושלים")
);

(document.getElementById(
    "petahTikvaBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectCity("פתח תקווה")
);

(document.getElementById(
    "hodHasharonBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectCity("הוד השרון")
);

(document.getElementById(
    "asianBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectType("אסייתי")
);

(document.getElementById(
    "meatBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectType("בשרי")
);

(document.getElementById(
    "italianBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectType("איטלקי")
);

(document.getElementById(
    "cafeBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectType("בתי קפה")
);

(document.getElementById(
    "kosherTrueBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectKosher("true")
);

(document.getElementById(
    "kosherFalseBtn"
) as HTMLElement).addEventListener(
    "click",
    () => selectKosher("false")
);

/*כפתור חזור*/
async function resetFilters()
{
    selectedCity = "";
    selectedType = "";
    selectedKosher = "";
    searchText = "";

    (
        document.getElementById(
            "searchInput"
        ) as HTMLInputElement
    ).value = "";

    (
        document.getElementById(
            "cityBtn"
        ) as HTMLButtonElement
    ).innerText = "בחר עיר ▾";

    (
        document.getElementById(
            "typeBtn"
        ) as HTMLButtonElement
    ).innerText = "סוג אוכל ▾";

    (
        document.getElementById(
            "kosher"
        ) as HTMLButtonElement
    ).innerText = "כשרות ▾";

    await loadRestaurants();

    closeModal();
}

const backBtn =
    document.getElementById(
        "backBtn"
    ) as HTMLButtonElement;

backBtn.addEventListener(
    "click",
    resetFilters
);


const confirmBookingBtn =
    document.getElementById(
        "confirmBookingBtn"
    ) as HTMLButtonElement;

confirmBookingBtn.addEventListener(
    "click",
    saveBooking
);
=======
import type { Item } from "types";
import { send } from "clientUtilities";
import { create } from "componentUtilities";

var itemInput = document.querySelector<HTMLInputElement>("#itemInput")!;
var amountInput = document.querySelector<HTMLInputElement>("#amountInput")!;
var addButton = document.querySelector<HTMLButtonElement>("#addButton")!;
var itemsUl = document.querySelector<HTMLUListElement>("#itemsUl")!;

var items = await send<Item[]>("getItems");

for (var i = 0; i < items.length; i++) {
  var itemLi = create("li");
  itemLi.innerText = `${items[i].amount} ${items[i].name}`;
  itemsUl.append(itemLi);
}

addButton.onclick = async function() {
  await send("addItem", itemInput.value, parseInt(amountInput.value));
  location.reload();
};
>>>>>>> 8535379cfb342f26e322fc84717b99ef8845e15c
