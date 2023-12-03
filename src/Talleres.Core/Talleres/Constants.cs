using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres
{
    public class Constants
    {
        public static decimal MILLISECONDS_HOUR => 1000 * 60 * 60;
        public enum RequestType
        {
            Workshop = 1,
            Rescue = 2,
            Assistance = 3
        }
        public enum ArticleRequestType
        {
            Request = 1,
            Return = 2,
            Additionals = 3,
            Output = 4,
            RequestForMaterials = 5,
            RequestByChanges
        }
        public enum ArticleRequestStatus
        {
            Rejected = 0,
            Created = 1,
            Sent = 2,
            PartiallyDispatched,
            Dispatched,
            Received,
            Closed,
            PendingReception,
            PendingDispatch
        }
        public enum RequestState
        {
            Cancel = 0,
            New,
            PendingReception,
            PendingInspection,
            Inspecting,
            Checking,
            PendingApproval,
            PendingShipping,
            Approved,
            Rejected,
            InProcess,
            PendingSettlement,
            Terminated,
            PendingBilling,
            AuthorizingGuarantee,
            Billed
        }

        public enum ChangeRequestState
        {
            PendingApproval = 0,
            Approved,
            Rejected
        }

        public enum ApprovalWay
        {
            Internal = 0,
            Phone = 1,
            Mail = 2,
            PurchaseOrder = 3
        }

        public enum FuelLevel
        {
            NoIdentificado = 0,
            Vacio,
            UnCuarto,
            UnMedio,
            TresCuarto,
            Lleno
        }

        public enum WorkTaskType
        {
            Clasic = 1,
            Service = 2
        }

        public enum WorkOrderState
        {
            PendingStart = 1,
            InProcess,
            InReview,
            Closed,
            Paused,
            Cancel
        }
        public enum WorkTaskState
        {
            Pending = 1,
            InProcess,
            Paused,
            Finished,
            ChangeOfTechnician
        }

        public enum GuaranteeType
        {
            NoAplica = 0,
            Interna,
            Externa,
        }

        public enum GuaranteeDetailStatus
        {
            Pending = 1,
            Approved,
            Reject
        }

        public enum GuaranteeStatus
        {
            Canceled = 0,
            PendingManagement = 1,
            PendingApproval = 2,
            PartialApproved = 3,
            PendingSettlement = 4,
            Settled = 5,
            PendingClose = 6,
            Close = 7,
            Reject = 8,
            PendingBilling = 9,
            Billed = 10,
        }

        public enum EventGuaranteeType
        {
            Canceled = 0,
            ClaimRecord,
            ApprovalRecord,
            Settled
        }

        public enum EventGuaranteeDetailStatus
        {
            Approved = 1,
            Reject
        }

        public enum QuotationType
        {
            Pieces = 1
        }

        public enum QuotationStatus
        {
            PendingSend = 1,
            PendingApproval,
            PendingBilling,
            PendingSettlement,
            Rejected,
            Billed,
            voided
        }

        public enum SaleType
        {
            Credit = 1,
            Counted = 2
        }
        public enum TypesAprobalCotization
        {
            Phone = 1,
            PurchaseOrder,
            Email,
            Agreement

        }

        public enum TypesDocumentQuotation
        {
            PendingApproval = 1,
            General
        }

        public enum Currencys
        {
            Usd = 11,
            Dop = 5
        }

        public enum EvidenceImagesType
        {
            reception = 0,
            despatch,
            deliverySignature,
            receiptSignature
        }
        public enum CheckList
        {
            PreventiveMaintenance = 1,
            Inspection = 2
        }

        public enum CombustionType
        {
            NoIdentificado = 0,
            Gasolina = 1,
            Gasoil = 2,
            Glp = 3,
            GasNatural = 4,
            Electrica = 5,
            Kerosene = 6,
            Carbon = 7,
            Hidrogeno = 8
        }

        public enum ReferenceType
        {
            Tab = 0,
            Serial = 1,
            Plate = 2,
            Chassis = 3,
        }

        public enum EquipmentType
        {
            Excavators = 1,
            FrontLoaders,
            DumpTrucks,
            CrushersAndScreens,
            ConveyorBelts,
            SievesAndSeparators,
            Generators,
            LoadingAndUnloadingEquipment,
            TransportVehicles,
            SecurityAndControlEquipment
        }

        public enum EquipmentState
        {
            PendingReception = 1,
            Received = 2,
            Dispatched = 3
        }

        public enum Origin
        {
            Solicitud = 1,
            Subsolicitud = 2,
            Recepcion = 3,
            SolicitudRechazo = 4,
            SolicitudDocumentoEliminar = 5,
            GarantiaExterna,
            GarantiaInterna,
            TareaTecnico,
            Despacho,
            Quotation,
            SolicitudInventario,
            ReversarActividad,
            TechnicianTask,
            RegistroCambio,
            RechazoRegistroCambio,
            AprobacionInspeccionFallas,
            RechazoAdicional,
            CancelarOrdenTrabajo,
            SalidaMaterialIndirecto,
            RechazoSalidaMaterialIndirecto,
            CancelarSolicitudGarantia
        }

        public enum BillOrigin
        {
            Request = 1,
            Quotation = 2,
            InspectionReject = 3,
            WorkOrderCancellation = 4,
            ApproveExternalGuarantee = 5,
            RejectExternalGuarantee = 6,
            Guarantee
        }

        /// <summary>
        /// Status for <see cref="Talleres.IndirectMaterialOutput"/>
        /// </summary>
        public enum IndirectMaterialOutputStatus
        {
            PendingApprobal = 1,
            Approved = 2,
            Rejected = 3
        }

        public enum SubRequestWorkTaskTechnicianOrigin
        {
            New = 1,
            Change = 2
        }

        /// <summary>
        /// Database Schemas.
        /// </summary>
        public static class DbSchemas
        {
            public const string Taller = "Taller";
        }
    }
}
