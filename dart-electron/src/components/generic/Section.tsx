interface Props {
    children: any
}

function Section(props: Props) {
    const {children} = props

    return (
        <section>{children}</section>
    )
}

export default Section
