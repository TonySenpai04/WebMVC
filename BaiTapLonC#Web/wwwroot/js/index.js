




function createProduct(product) {
    var productHTML = `
        
            <div class="item">
                <div class="thumb">
                    <div class="hover-content">
                        <ul >
                            <li  onclick="Detail('${product.name}','${product.price}','${product.imageUrl}','${product.description}')"><a href="#"><i class="fa fa-eye"></i></a></li>
                            <li  onclick="Detail('${product.name}','${product.price}','${product.imageUrl}','${product.description}')"><a href="#"><i class="fa fa-star"></i></a></li>
                            <li  onclick="Detail('${product.name}','${product.price}','${product.imageUrl}','${product.description}')"><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                        </ul>
                    </div>
                    <img src="${product.imageUrl}" alt="">
                </div>
                <div class="down-content">
                    <h4>${product.name}</h4>
                    <span>$${product.price.toFixed(2)}</span>
                    <ul class="stars">
                        ${'<li><i class="fa fa-star"></i></li>'.repeat(product.stars)}
                    </ul>
                </div>
            </div>
    `;
    return productHTML;
}

// Function để chèn sản phẩm vào container
function renderProducts(id,productsData) {
    var productContainer = document.getElementById(id);
    var productsHTML = '';

    // Tạo và chèn từng sản phẩm vào container
    productsData.forEach(function (productsData) {
        productsHTML += createProduct(productsData);
    });

    // Chèn tất cả sản phẩm vào container
    productContainer.innerHTML = productsHTML;
    
   
}



// Địa chỉ API
const apiWomanUrl = 'https://localhost:7264/productwomen/index';
const apiMenUrl = 'https://localhost:7264/productmen/index';
const apiKidUrl = 'https://localhost:7264/productkids/index';



async function GetData(apiUrl) {
    try {
        const response = await fetch(apiUrl);

        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Fetch error:', error);
        throw error; 
    }
}
function Detail(productName, productPrice, productImage, productDescription){
    var url = "singleproduct?name=" + encodeURIComponent(productName) + "&price=" + encodeURIComponent(productPrice) +
    "&image=" + encodeURIComponent(productImage) + "&description=" + encodeURIComponent(productDescription);
    window.location.href = url;

    
}
const apiUrls = [apiMenUrl, apiWomanUrl, apiKidUrl];
var productsMenData = [];
var productsWomenData = [];
var productsKidData = [];
async function fetchData() {
    try {

        const apiData = await Promise.all(
            apiUrls.map(apiUrl => GetData(apiUrl))

        );

        productsMenData = apiData[0];
        productsWomenData = apiData[1]
        productsKidData = apiData[2];

    } catch (error) {
        console.log(error);
    }
}
function addOwlCarouselScript() {
    const scriptElement = document.createElement("script");
    scriptElement.src = "js/owl-carousel.js";
    document.body.appendChild(scriptElement);
}
function addCustomScript() {
    const scriptElement = document.createElement("script");
    scriptElement.src = "js/custom.js";
    document.body.appendChild(scriptElement);
}
async function fetchDataAndInitCarousel() {
    try {
        await fetchData();
        addOwlCarouselScript();
       addCustomScript();
        renderProducts("productList", productsMenData);
        renderProducts("productWomanList", productsWomenData);
        renderProducts("productKidList", productsKidData);

      
    } catch (error) {
        console.error(error);
    }
}

fetchDataAndInitCarousel();
