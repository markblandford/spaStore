import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public getProductsResponse = `
    [
	    {
		    "id": 1,
		    "name": "Butter",
		    "price": 0.8
	    },
	    {
		    "id": 2,
		    "name": "Milk",
		    "price": 1.15
	    },
	    {
		    "id": 3,
		    "name": "Bread",
		    "price": 1.0
	    }
    ]`;

    public putBasketBody = `
    {
        "id": null,
        "items": [
            {
                "id": 3,
                "name": "bread",
                "price": 1
            },
            {
                "id": 1,
                "name": "butter",
                "price": 0.8
            }
        ]
    }`;

    public putBasketResponse = `
    {
        "id": "fa25be2f-0b59-4e8d-8217-af7c1da42b16",
        "items": [
            {
                "id": 3,
                "name": "Bread",
                "price": 1.0
            },
            {
                "id": 1,
                "name": "Butter",
                "price": 0.8
            }
        ]
    }`;
}
