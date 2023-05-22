export interface News {
    id: number
    title: string
    subTitle: string
    authorName: string
    information: string
    status: string
    isHot: boolean
    type: string | null
    publishedAt: Date
    edittedAt: Date | null
}

export interface EditNewsModel {
    id: number
    title: string
    subTitle: string
    authorName: string
    information: string
    status: string
    isHot: boolean
    type: string | null
}