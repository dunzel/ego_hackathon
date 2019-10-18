import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Reservation {
    start: Date;
    end: Date;
}

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    apiURL: string = 'http://localhost:50432';

    constructor(private httpClient: HttpClient) {}

    public getReservations(){
        console.log('Hello World');
        this.httpClient.get(`${this.apiURL}/api/Reservations`).subscribe((res)=>{
            console.log(res);
        });
    }
}
