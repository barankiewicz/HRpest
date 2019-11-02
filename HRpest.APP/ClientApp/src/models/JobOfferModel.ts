class JobOfferModel{
    id!: number;

    createdOn: Date;
    endedOn: Date;
    active!: boolean;
    createdBy!: string;

    employmentType: EmploymentType;
    positionLevel: PositionLevel;

    hoursWeekly: number;
    remoteHoursWeekly: number;
    minimumPay: number;
    maximumPay: number;

    positionName!: string;
    jobDescription!: string;
    usualTasks!: string;
    jobRequirements!: string;
    jobBenefits!: string;
}