export default function Footer() {
    return (
    <footer className="vh-10 overflow-auto">
        <div className="row justify-content-center align-items-center">
            <img src="/image/facebook.png" className="img-fluid" alt="Image 1" style={{ maxWidth: "50px", maxHeight: "50px" }}/>
            <img src="/image/twitter-icon-free-png.png" className="img-fluid" style={{ maxWidth: "50px", maxHeight: "50px" }}/>
            <img src="/image/6297a2f1e01809629f113598.png" className="img-fluid" style={{ maxWidth: "60px", maxHeight: "60px" }}/>
        </div>
        <div className="d-flex flex-column justify-content-center align-items-center">
            <p className="text-white">Centre d'Expertise et de Perfectionnement en Informatique</p>
            <p className="text-white">Copyright © 2023. Tous droits réservés.</p>
        </div>
    </footer>
    );
}