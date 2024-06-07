import './Sponsored.css'
import { DataSponsored } from './dataSponsored'

export default function SponsoredSection() {
    const List_Sponsored=DataSponsored.map(DataSponsored=>
        <div className="sponsored-sections">
                <div className="sponsored-sections-is">
                    <img src={DataSponsored.src}></img>
                    <div className="descri">
                        <div className="descri-top">
                            <p>{DataSponsored.descri}</p>
                        </div>
                        <div className="descri-bot">
                            <p>{DataSponsored.link}</p>
                        </div>
                    </div>
                </div>
            </div>
    )


    return(
        <div className="sponsored">
            {List_Sponsored}
         </div>
    )
}