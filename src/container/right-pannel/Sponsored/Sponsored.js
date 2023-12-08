import './Sponsored.css'
import { DataSponsored } from './dataSponsored'

export default function SponsoredSection() {
    const List_Sponsored=DataSponsored.map(DataSponsored=>
        <div class="sponsored-sections">
                <div class="sponsored-sections-is">
                    <img src={DataSponsored.src}></img>
                    <div class="descri">
                        <div class="descri-top">
                            <p>{DataSponsored.descri}</p>
                        </div>
                        <div class="descri-bot">
                            <p>{DataSponsored.link}</p>
                        </div>
                    </div>
                </div>
            </div>
    )


    return(
        <div class="sponsored">
            <ul>{List_Sponsored}</ul>
         </div>
    )
}