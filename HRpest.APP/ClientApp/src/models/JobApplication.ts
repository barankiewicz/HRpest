class JobApplication{
    id!: number;

    createdOn: Date;
    editedOn: Date;
    deletedOn: Date;

    applicant!: string;
    jobOffer: JobOfferModel;

    applicationStatus: ApplicationStatus;
    cvHandle: string;
    additionalInformation: string;
}