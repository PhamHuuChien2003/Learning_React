import './cmt.css'

import MyCmt from './mycmt/mycmt'
import CmtA from './publiccmt/publiccmt'

export default function Cmt(DataCmt) {


    return (
        <>
            <div className="cmt-bl-post">
                <div className="cmt-1-p-1">
                    <div className="view-more">
                        <p>View more comment</p>
                    </div>
                    <CmtA {...DataCmt} />
                    <MyCmt/>
                </div>
            </div>
        </>
    )
}
