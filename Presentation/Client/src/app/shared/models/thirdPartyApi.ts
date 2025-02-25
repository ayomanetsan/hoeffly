export interface ImgBBResponse {
    data: ImgBBData
    success: boolean
    status: number
}

interface ImgBBData {
    id: string
    title: string
    url_viewer: string
    url: string
    display_url: string
    width: number
    height: number
    size: number
    time: number
    expiration: number
    image: ImageBB
    thumb: ImageBB
    delete_url: string
}

interface ImageBB {
    filename: string
    name: string
    mime: string
    extension: string
    url: string
}
