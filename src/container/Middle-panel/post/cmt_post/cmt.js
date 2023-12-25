import './cmt.css'

import MyCmt from './mycmt/mycmt'
import CmtA from './publiccmt/publiccmt'

export default function Cmt(DataCmt) {


    return (
        <>
            <div class="cmt-bl-post">
                <div class="cmt-1-p-1">
                    <div class="view-more">
                        <p>View more comment</p>
                    </div>
                    <CmtA {...DataCmt} />
                    <MyCmt/>
                </div>
            </div>
        </>
    )
}
