"use client";
import React from "react";
import Link from 'next/link';

export default  function Error(){
    
    return (
        <div className="d-flex justify-content-center align-items-center w-100">
                <div className="card m-2 w-50">
                    <img 
                        src="/image/pour_page_erreur.gif" 
                        className="card-img-top img-fluid w-100" 
                        alt="Image 1"
                    />
                    <div className="card-body">
                        <div className="text-center">
                        <h5 className="card-title fw-bold">Erreur dans l'application! Retour à la page d'accueil</h5>
                            <Link className="btn text-white" href="../">
                                <img src="/image/LAW-removebg-preview.png" alt="Bootstrap" width="50%" height="50%" />
                            </Link>
                            
                        </div>
                    </div>
                </div>                     
        </div>
    )
}