"use client"
import Link from 'next/link';
import React, { useState } from 'react';

export default function Acceuil(props){
    return (
        <div className="d-flex justify-content-center align-items-center w-100">
                <div className="card m-2 w-50">
                    <img 
                        src="/image/ZoneBG.png" 
                        className="card-img-top img-fluid w-100" 
                        alt="Image 1"
                    />
                    <div className="card-body">
                        <div className="text-center">
                        <h5 className="card-title fw-bold">Obtenez votre Cosplay pour une allure Excepionnelle !</h5>
                            <Link className="btn text-white" href="./Connexion">
                                <img src="/image/LAW-removebg-preview.png" alt="Bootstrap" width="50%" height="50%" />
                            </Link>
                            
                        </div>
                    </div>
                </div>                     
        </div>
    )
}
