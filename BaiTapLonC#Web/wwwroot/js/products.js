function createProductItem(product) {
    var item = document.createElement("div");
    item.className = "col-lg-4";
    item.innerHTML = `
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
                    </div>
                `;
    return item;
}

function addProductsToPage(products) {
    var productRow = document.getElementById("productRow");
    products.forEach(function (product) {
        var productItem = createProductItem(product);
        productRow.appendChild(productItem);
    });
}

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
const apiMenUrl = 'https://localhost:7264/productmen/index';
const apiWomanUrl = 'https://localhost:7264/productwomen/index';
const apiKidUrl = 'https://localhost:7264/productkids/index';

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
        var products = productsMenData.concat(productsWomenData, productsKidData);
        addProductsToPage(products);

    } catch (error) {
        console.log(error);
    }
}
fetchData();
function Detail(productName, productPrice, productImage, productDescription) {
    var url = "singleproduct?name=" + encodeURIComponent(productName) + "&price=" + encodeURIComponent(productPrice) +
        "&image=" + encodeURIComponent(productImage) + "&description=" + encodeURIComponent(productDescription);
    window.location.href = url;

}
